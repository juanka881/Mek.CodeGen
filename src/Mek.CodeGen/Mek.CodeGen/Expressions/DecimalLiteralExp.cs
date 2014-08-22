using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class DecimalLiteralExp : LiteralExp<decimal>
	{
		public DecimalLiteralExp(decimal val)
			: base(val)
		{

		}
	}
}