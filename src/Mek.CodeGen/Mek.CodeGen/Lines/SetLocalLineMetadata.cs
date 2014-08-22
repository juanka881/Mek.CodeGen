using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Lines
{
	public class SetLocalLineMetadata : LineMetadata
	{
		public readonly LocalExp Local;

		public readonly ExpMetadata Value;

		public SetLocalLineMetadata(LocalExp localExp, ExpMetadata valueExp)
		{
			if(localExp == null)
				throw new ArgumentNullException("localExp");

			if(valueExp == null)
				throw new ArgumentNullException("valueExp");

			this.Local = localExp;
			this.Value = valueExp;
		}
	}
}