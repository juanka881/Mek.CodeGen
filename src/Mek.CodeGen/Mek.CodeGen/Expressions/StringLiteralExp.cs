using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class StringLiteralExp : LiteralExp<string>
	{
		public StringLiteralExp(string str) : base(str)
		{
			
		}
	}
}