using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class Int32LiteralExp : LiteralExp<int>
	{
		public Int32LiteralExp(int number) : base(number)
		{

		}
	}
}