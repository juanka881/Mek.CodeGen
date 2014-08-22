using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mek.CodeGen
{
	public class AssemblyMetadata : BaseMetadata
	{
		private TypeAttributes typeAttributes;

		private readonly IList<TypeMetadata> types;

		private string currentNamespace;

		public IEnumerable<TypeMetadata> Types
		{
			get
			{
				return this.types;
			}
		}

		public AssemblyMetadata(string assemblyName) : base(assemblyName)
		{
			this.typeAttributes = TypeAttributes.Public;
			this.types = new List<TypeMetadata>();
			this.currentNamespace = assemblyName;
		}

		private string GetQualifiedTypeName(string typeName)
		{
			if(string.IsNullOrWhiteSpace(typeName))
				throw new ArgumentException("typeName is empty or null", "typeName");

			if(string.IsNullOrWhiteSpace(this.currentNamespace))
			{
				return typeName;
			}
			else
			{
				return string.Format("{0}.{1}", this.currentNamespace, typeName);
			}
		}

		public AssemblyMetadata Public 
		{
			get
			{
				this.typeAttributes = TypeAttributes.Public;
				return this;
			}
		}

		public AssemblyMetadata Private
		{
			get
			{
				this.typeAttributes = TypeAttributes.NotPublic;
				return this;
			}
		}

		public IDisposable Namespace(string newNamespace)
		{
			if(string.IsNullOrWhiteSpace(newNamespace))
				throw new ArgumentException("newNamespace is empty or null", "newNamespace");

			var oldNamespace = this.currentNamespace;
			var ctx = new AssemblyMetadataNamespaceContext(() => this.currentNamespace = oldNamespace);
			this.currentNamespace = newNamespace;
			return ctx;
		}

		public ClassMetadata Class(string className)
		{
			var classGen = new ClassMetadata(this.GetQualifiedTypeName(className), this.typeAttributes);
			this.types.Add(classGen);
			return classGen;
		}
	}
}