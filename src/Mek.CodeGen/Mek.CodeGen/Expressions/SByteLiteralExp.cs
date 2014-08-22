using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class SByteLiteralExp : LiteralExp<sbyte>
	{
		public SByteLiteralExp(sbyte val) : base(val)
		{

		}
	}
}