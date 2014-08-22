using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class CodeGen
	{
		public static AssemblyMetadata Assembly(string name)
		{
			var assembly = new AssemblyMetadata(name);
			return assembly;
		}

		public static T GetActivator<T>()
		{
			return default(T);
		}
	}
}