using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mek.CodeGen
{
	public class ClassMetadata : TypeMetadata
	{
		private IDictionary<string, MethodMetadata> methods;
		
		public ClassMetadata(string className, TypeAttributes attrs) : base(className, attrs)
		{
			this.methods = new Dictionary<string, MethodMetadata>();
		}

		public IEnumerable<MethodMetadata> Methods
		{
			get
			{
				return this.methods.Values;
			}
		}

		public ClassMetadata Inherit(Type baseType)
		{
			if (baseType == null)
				throw new ArgumentNullException("baseType");

			if (baseType.IsSealed)
				throw BaseTypeIsSealedException.Get(baseType);

			if (!baseType.IsClass)
				throw BaseTypeIsNotAClassException.Get(baseType);

			this.BaseType = baseType;
			return this;
		}

		public ClassMetadata Implements(Type interfaceType)
		{
			if(interfaceType == null)
				throw new ArgumentNullException("interfaceType");

			this.interfaceTypes.Add(interfaceType);
			return this;
		}

		public MethodMetadata Method(string methodName)
		{
			var method = new MethodMetadata(methodName);
			this.methods[methodName] = method;
			return method;
		}
	}
}