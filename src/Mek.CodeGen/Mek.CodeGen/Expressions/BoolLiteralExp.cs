using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class BoolLiteralExp : LiteralExp<bool>
	{
		public BoolLiteralExp(bool val) : base(val)
		{
			
		}
	}
}