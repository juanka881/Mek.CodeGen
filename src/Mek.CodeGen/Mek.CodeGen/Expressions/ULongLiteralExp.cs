using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class ULongLiteralExp : LiteralExp<ulong>
	{
		public ULongLiteralExp(ulong val)
			: base(val)
		{

		}
	}
}