using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class DoubleLiteralExp : LiteralExp<double>
	{
		public DoubleLiteralExp(double val)
			: base(val)
		{

		}
	}
}