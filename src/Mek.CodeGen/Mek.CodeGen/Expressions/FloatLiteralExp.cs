using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class FloatLiteralExp : LiteralExp<float>
	{
		public FloatLiteralExp(float val)
			: base(val)
		{

		}
	}
}