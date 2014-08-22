using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mek.CodeGen
{
	public class TypeMetadata : BaseMetadata
	{
		protected readonly IList<Type> interfaceTypes;
		private TypeAttributes attributes;

		public TypeMetadata(string typeName, TypeAttributes attrs) : base(typeName)
		{
			this.interfaceTypes = new List<Type>();
			this.attributes = attrs;
			this.BaseType = typeof(object);
		}

		public Type BaseType { get; protected set; }

		public IEnumerable<Type> InterfaceTypes
		{
			get
			{
				return this.interfaceTypes;
			}
		}

		public TypeAttributes Attributes
		{
			get
			{
				return this.attributes;
			}
		}
	}
}