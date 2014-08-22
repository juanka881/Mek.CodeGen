using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Lines
{
	public class ReturnLineMetadata : LineMetadata
	{
		public readonly ExpMetadata Exp;

		public ReturnLineMetadata(ExpMetadata exp)
		{
			if(exp == null)
				throw new ArgumentNullException("exp");

			this.Exp = exp;
		}
	}
}