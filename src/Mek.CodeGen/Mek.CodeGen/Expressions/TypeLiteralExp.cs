using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class TypeLiteralExp : LiteralExp<Type>
	{
		public TypeLiteralExp(Type type) : base(type)
		{
			
		}
	}
}