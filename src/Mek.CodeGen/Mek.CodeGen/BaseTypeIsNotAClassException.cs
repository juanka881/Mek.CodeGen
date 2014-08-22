using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Mek.CodeGen
{
	[Serializable]
	public class BaseTypeIsNotAClassException : Exception
	{
		public BaseTypeIsNotAClassException()
		{
		}

		public BaseTypeIsNotAClassException(string message) : base(message)
		{
		}

		public BaseTypeIsNotAClassException(string message, Exception inner) : base(message, inner)
		{
		}

		protected BaseTypeIsNotAClassException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}

		public static BaseTypeIsNotAClassException Get(Type baseType)
		{
			var ex = new BaseTypeIsNotAClassException("unable to use base type as base for new type because it is not a class");
			ex.Data["base-type"] = baseType.ToString();
			return ex;
		}
	}
}