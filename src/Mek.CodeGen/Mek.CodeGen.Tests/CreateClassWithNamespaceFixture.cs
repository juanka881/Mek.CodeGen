using Mek.CodeGen.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mek.CodeGen.Tests
{
	[TestFixture]
	public class CreateClassWithNamespaceFixture : CreateTypeFixture
	{
		public override IEnumerable<TestCaseData> Cases()
		{
			var ns = "foo.test";

			yield return this.GetCase("create public class with ns", x =>
			{
				x.Namespace("foo");
				x.Public.Class("test");
			}, t => t.IsPublic && t.FullName == ns);

			yield return this.GetCase("create private class with ns", x =>
			{
				x.Namespace("foo");
				x.Private.Class("test");
			}, t => t.IsNotPublic && t.FullName == ns);
		}
	}
}

