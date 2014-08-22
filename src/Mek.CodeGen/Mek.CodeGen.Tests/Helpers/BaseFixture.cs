using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mek.CodeGen.Tests.Helpers
{
	public abstract class BaseFixture
	{
		public Assembly CreateAssembly(Action<AssemblyMetadata> fn)
		{
			var asm = new AssemblyMetadata("test");
			fn(asm);
			return new DynamicAssemblyGenerator().Generate(asm);
		}
	}
}