using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using Mek.CodeGen.Expressions;
using Mek.CodeGen.Lines;

namespace Mek.CodeGen
{
	public class DynamicAssemblyGenerator
	{
		private Lazy<DynamicLineGenerator> lineGenerator;

		private static AssemblyBuilder GetAssemblyBuilder(string name, bool canBeCollected)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name is empty or null", "name");

			var assemblyName = new AssemblyName(name);
			var access = AssemblyBuilderAccess.Run;

			var builder = null as AssemblyBuilder;

			if (canBeCollected)
				access = AssemblyBuilderAccess.RunAndCollect;

			builder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, access);

			return builder;
		}

		public DynamicAssemblyGenerator()
		{
			this.lineGenerator = new Lazy<DynamicLineGenerator>(() => new DynamicLineGenerator(), LazyThreadSafetyMode.ExecutionAndPublication);
		}

		public Assembly Generate(AssemblyMetadata assemblyMetadata)
		{
			if(assemblyMetadata == null)
				throw new ArgumentNullException("assemblyMetadata");

			var assembly = GetAssemblyBuilder(assemblyMetadata.Name, true);
			var moduleName = string.Format("{0}_Module", assemblyMetadata.Name);
			var module = assembly.DefineDynamicModule(moduleName);

			this.GenerateTypes(module, assemblyMetadata.Types);

			return assembly;
		}

		private void GenerateTypes(ModuleBuilder module, IEnumerable<TypeMetadata> types)
		{
			foreach(var type in types)
				this.GenerateType(module, type);
		}

		private void GenerateType(ModuleBuilder module, TypeMetadata typeMetadata)
		{
			if(typeMetadata == null)
				throw new ArgumentNullException("typeMetadata");

			if(typeMetadata is ClassMetadata)
			{
				this.GenerateClass(module, typeMetadata as ClassMetadata);
			}
			else
			{
				throw new InvalidOperationException("unknown method");
			}
		}

		private void GenerateClass(ModuleBuilder module, ClassMetadata cls)
		{
			if(module == null)
				throw new ArgumentNullException("module");

			if(cls == null)
				throw new ArgumentNullException("cls");

			var type = module.DefineType(cls.Name, cls.Attributes, cls.BaseType, cls.InterfaceTypes.ToArray());

			foreach(var method in cls.Methods)
			{
				this.GenerateMethod(type, method);
			}

			type.CreateType();
		}

		private void GenerateMethod(TypeBuilder type, MethodMetadata methodMetadata)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(methodMetadata == null)
				throw new ArgumentNullException("methodMetadata");

			var attrs = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig;
			var callingConvenction = CallingConventions.HasThis;
			var parameters = methodMetadata.Parameters.Select(x => x.Type).ToArray();

			var method = type.DefineMethod(methodMetadata.Name, attrs, callingConvenction, methodMetadata.ReturnType, parameters);

			var il = method.GetILGenerator();
			var g = new DynamicILGenerator(il);

			foreach(var parameter in methodMetadata.Parameters)
				method.DefineParameter(parameter.Position, ParameterAttributes.None, parameter.Name);

			foreach(var local in methodMetadata.Block.Locals)
				g.DeclareLocal(local);

			foreach(var line in methodMetadata.Block.Lines)
				this.GenerateLine(g, line);
		}

		private void GenerateLine(DynamicILGenerator g, LineMetadata line)
		{
			this.lineGenerator.Value.Emit(g, line);
		}
	}
}