using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class MethodMetadata : BaseMetadata
	{
		
		private Type returnType;
		private IDictionary<string, ParameterExp> parameters;
		private int parameterPosition;
		private BlockMetadata block;

		public MethodMetadata(string methodName) : base(methodName)
		{
			this.parameters = new Dictionary<string, ParameterExp>();
			this.parameterPosition = -1;
			this.returnType = typeof(void);
			this.block = null;
		}

		public Type ReturnType
		{
			get
			{
				return this.returnType;
			}
		}

		public IEnumerable<ParameterExp> Parameters
		{
			get
			{
				return this.parameters.Values;
			}
		}

		public BlockMetadata Block
		{
			get
			{
				return this.block;
			}
		}

		public MethodMetadata Returns(Type type)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			this.returnType = type;
			return this;
		}

		public MethodMetadata Parameter(Type type, string parameterName)
		{
			if(parameterName == null)
				throw new ArgumentNullException("parameterName");

			if(type == null)
				throw new ArgumentNullException("type");

			this.parameterPosition += 1;
			var parameterExp = new ParameterExp(parameterPosition, parameterName, type);
			this.parameters[parameterName] = parameterExp;

			return this;
		}

		public MethodMetadata Body(Action<BlockMetadata> fn)
		{
			this.block = new BlockMetadata(this.returnType, this.parameters);
			fn(this.block);
			return this;
		}
	}
}