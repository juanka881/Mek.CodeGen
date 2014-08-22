using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class LongLiteralExp : LiteralExp<long>
	{
		public LongLiteralExp(long val)
			: base(val)
		{

		}
	}
}