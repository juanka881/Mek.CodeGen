using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen.Lines
{
	public class NoopLineMetadata : LineMetadata
	{
		public static readonly NoopLineMetadata Instance = new NoopLineMetadata();

		private NoopLineMetadata()
		{
			
		}
	}
}