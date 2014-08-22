using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Lines
{
	public class SetParameterLineMetadata : LineMetadata
	{
		public readonly ParameterExp Parameter;
		public readonly ExpMetadata Value;

		public SetParameterLineMetadata(ParameterExp paramExp, ExpMetadata valueExp)
		{
			if(paramExp == null)
				throw new ArgumentNullException("paramExp");

			if(valueExp == null)
				throw new ArgumentNullException("valueExp");

			this.Parameter = paramExp;
			this.Value = valueExp;
		}
	}
}