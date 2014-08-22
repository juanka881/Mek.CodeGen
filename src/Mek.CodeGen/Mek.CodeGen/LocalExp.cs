using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class LocalExp : ExpMetadata
	{
		public readonly ExpMetadata InitialValue;
		
		public LocalExp(Type type, ExpMetadata initValue)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(initValue == null)
				throw new ArgumentNullException("initValue");

			this.Type = type;
			this.InitialValue = initValue;
		}
	}
}