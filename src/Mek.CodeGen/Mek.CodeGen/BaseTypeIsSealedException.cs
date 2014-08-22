using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Mek.CodeGen
{
	[Serializable]
	public class BaseTypeIsSealedException : Exception
	{
		public BaseTypeIsSealedException()
		{
		}

		public BaseTypeIsSealedException(string message) : base(message)
		{
		}

		public BaseTypeIsSealedException(string message, Exception inner) : base(message, inner)
		{
		}

		protected BaseTypeIsSealedException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}

		public static BaseTypeIsSealedException Get(Type baseType)
		{
			var ex = new BaseTypeIsSealedException("unable to use base type as base for new type because type is sealed");
			ex.Data["base-type"] = baseType.ToString();
			return ex;
		}
	}
}