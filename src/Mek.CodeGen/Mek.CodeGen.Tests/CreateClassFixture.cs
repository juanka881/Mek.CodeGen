using System;
using System.Collections.Generic;
using System.Linq;
using Mek.CodeGen.Tests.Helpers;
using NUnit.Framework;

namespace Mek.CodeGen.Tests
{
	[TestFixture]
	public class CreateClassFixture : CreateTypeFixture
	{
		public override IEnumerable<TestCaseData> Cases()
		{
			yield return this.GetCase("create public class", x => x.Public.Class("test"), t => t.IsPublic);
			yield return this.GetCase("create private class", x => x.Private.Class("test"), t => t.IsNotPublic);
		}
	}
}