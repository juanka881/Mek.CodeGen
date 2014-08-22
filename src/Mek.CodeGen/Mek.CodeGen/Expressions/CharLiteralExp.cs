using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class CharLiteralExp : LiteralExp<char>
	{
		public CharLiteralExp(char val)
			: base(val)
		{

		}
	}
}