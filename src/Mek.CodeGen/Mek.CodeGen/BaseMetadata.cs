using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class BaseMetadata
	{
		public readonly string Name;

		public BaseMetadata(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name is empty or null", "name");

			this.Name = name;
		}
	}
}