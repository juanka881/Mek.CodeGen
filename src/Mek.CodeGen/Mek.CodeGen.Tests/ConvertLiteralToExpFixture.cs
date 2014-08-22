using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mek.CodeGen.Tests
{
	[TestFixture]
	public class ConvertLiteralToExpFixture
	{
		public enum TestEnum
		{
			One
		}

		public IEnumerable<TestCaseData> Cases()
		{
			yield return this.GetCase(null);
			yield return this.GetCase(typeof(void));
			yield return this.GetCase("hello");
			yield return this.GetCase(false);
			yield return this.GetCase(byte.MaxValue);
			yield return this.GetCase(sbyte.MaxValue);
			yield return this.GetCase(short.MaxValue);
			yield return this.GetCase(ushort.MaxValue);
			yield return this.GetCase(char.MaxValue);
			yield return this.GetCase(uint.MaxValue);
			yield return this.GetCase(long.MaxValue);
			yield return this.GetCase(ulong.MaxValue);
			yield return this.GetCase(float.MaxValue);
			yield return this.GetCase(double.MaxValue);
			yield return this.GetCase(char.MaxValue);
			yield return this.GetCase(decimal.MaxValue);
			yield return this.GetCase(TestEnum.One);
		}

		public TestCaseData GetCase(object val)
		{
			var name = val == null ? "null" : val.GetType().Name;
			return new TestCaseData(val).SetName(string.Format("convert {0} to literal exp", name));
		}

		[TestCaseSource("Cases")]
		public void Test(object val)
		{
			var exp = ExpMetadata.From(val);
			Assert.IsNotNull(exp);
		}
	}
}