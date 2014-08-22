using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class ByteLiteralExp : LiteralExp<byte>
	{
		public ByteLiteralExp(byte val) : base(val)
		{

		}
	}
}