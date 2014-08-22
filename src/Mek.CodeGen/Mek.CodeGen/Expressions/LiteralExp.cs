using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class LiteralExp : ExpMetadata
	{
		
	}

	public class LiteralExp<T> : LiteralExp
	{
		public readonly T Value;

		public LiteralExp(T val)
		{
			this.Value = val;
			this.Type = typeof(T);
		}
	}
}