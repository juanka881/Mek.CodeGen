using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Expressions
{
	public class NullExp : LiteralExp
	{
		public static readonly NullExp Instance = new NullExp();

		private NullExp()
		{
			
		}
	}
}