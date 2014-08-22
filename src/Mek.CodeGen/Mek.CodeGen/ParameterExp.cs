using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class ParameterExp : ExpMetadata
	{
		public int Position { get; set; }
		public string Name { get; set; }
		
		public ParameterExp(int position, string name, Type type)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name is empty or null", "name");

			if(type == null)
				throw new ArgumentNullException("type");

			this.Position = position;
			this.Name = name;
			this.Type = type;
		}
	}
}