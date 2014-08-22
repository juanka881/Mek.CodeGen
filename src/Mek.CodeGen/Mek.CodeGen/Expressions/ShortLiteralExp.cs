using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class ShortLiteralExp : LiteralExp<short>
	{
		public ShortLiteralExp(short val)
			: base(val)
		{

		}
	}
}