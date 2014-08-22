using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class EnumLiteralExp : LiteralExp<Enum>
	{
		public EnumLiteralExp(Enum val)
			: base(val)
		{

		}
	}
}