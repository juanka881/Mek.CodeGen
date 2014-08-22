using Mek.CodeGen.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using Mek.CodeGen.Lines;

namespace Mek.CodeGen
{
	public class BlockMetadata
	{
		private readonly IList<LineMetadata> lines;
		private readonly Type returnType;
		private readonly IList<LocalExp> locals;
		private readonly IDictionary<string, ParameterExp> parameters;
		
		public BlockMetadata(Type returnType, IDictionary<string, ParameterExp> parameters)
		{
			if(returnType == null)
				throw new ArgumentNullException("returnType");

			if(parameters == null)
				throw new ArgumentNullException("parameters");

			this.lines = new List<LineMetadata>();
			this.returnType = returnType;
			this.locals = new List<LocalExp>();
			this.parameters = parameters;
		}

		public IEnumerable<LineMetadata> Lines
		{
			get
			{
				return this.lines;
			}
		}

		public IEnumerable<LocalExp> Locals
		{
			get
			{
				return this.locals;
			}
		}

		public void Noop()
		{
			this.lines.Add(NoopLineMetadata.Instance);
		}

		public void Return(ExpMetadata value)
		{
			if(value == null)
				throw new ArgumentNullException("value");

			if(this.returnType == typeof(void) && value != ExpMetadata.None)
				throw new Exception("attempted to return a value but the method is void");

			if(this.returnType != typeof(void) && value == ExpMetadata.None)
				throw new Exception(string.Format("attempted to return without a value, but a return value of type {0} is expected", this.returnType));

			if(!(value is NullExp) && this.returnType != value.Type)
				throw new Exception(string.Format("attempted to return an invalid value type, expected {0}, got {1}", this.returnType, value.Type)); 

			this.lines.Add(new ReturnLineMetadata(value));
		}

		public void Return()
		{
			this.Return(ExpMetadata.None);
		}

		public ParameterExp Parameter(int pos)
		{
			var param = this.parameters.Values
				.Where(x => x.Position == pos)
				.FirstOrDefault();

			if(param == null)
				throw new Exception(string.Format("unable to find param at index {0}", pos));

			return param;
		}

		public ParameterExp Parameter(string name)
		{
			var param = null as ParameterExp;
			if(!this.parameters.TryGetValue(name, out param))
				throw new Exception(string.Format("unable to find param named {0}", name));

			return param;
		}

		public LocalExp Local(Type type, ExpMetadata initValue)
		{
			var newVar = new LocalExp(type, initValue);
			this.locals.Add(newVar);

			if(initValue != ExpMetadata.None)
				this.Set(newVar, initValue);

			return newVar;
		}

		public LocalExp Local(Type type)
		{
			return this.Local(type, ExpMetadata.None);
		}

		public void Set(LocalExp localExp, ExpMetadata valueExp)
		{
			this.lines.Add(new SetLocalLineMetadata(localExp, valueExp));
		}

		public void Set(ParameterExp paramExp, ExpMetadata valueExp)
		{
			this.lines.Add(new SetParameterLineMetadata(paramExp, valueExp));
		}
	}
}