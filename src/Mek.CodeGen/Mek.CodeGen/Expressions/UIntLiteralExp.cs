using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class UIntLiteralExp : LiteralExp<uint>
	{
		public UIntLiteralExp(uint val)
			: base(val)
		{

		}
	}
}