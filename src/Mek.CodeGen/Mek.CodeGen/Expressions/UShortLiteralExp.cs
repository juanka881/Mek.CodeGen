using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class UShortLiteralExp : LiteralExp<ushort>
	{
		public UShortLiteralExp(ushort val) : base(val)
		{

		}
	}
}