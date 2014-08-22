using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mek.CodeGen.Tests.Helpers
{
	public abstract class CreateTypeFixture : BaseFixture
	{
		public virtual IEnumerable<TestCaseData> Cases()
		{
			yield break;
		}

		public TestCaseData GetCase(string name, Action<AssemblyMetadata> fn, Func<Type, bool> validator)
		{
			return new TestCaseData(fn, validator).SetName(name);
		}

		[TestCaseSource("Cases")]
		public void Test(Action<AssemblyMetadata> fn, Func<Type, bool> validator)
		{
			var type = this.CreateAssembly(fn).GetTypes().FirstOrDefault();
			Assert.IsNotNull(type, "type exists");
			Assert.IsTrue(validator(type), "type is valid");
		}

		[Test]
		public void Test1()
		{
			var asm = this.CreateAssembly(x =>
			{
				var hello = x.Public.Class("bar")
					.Method("hello")
					.Returns(typeof(string))
					.Parameter(typeof(string), "name");
				
				hello.Body(g =>
				{
					var namep = g.Parameter("name");

					g.Set(namep, "foobar");
					g.Return(namep);
				});
			});

			var type = asm.GetTypes().FirstOrDefault();
			var ins = Activator.CreateInstance(type);
			var r = type.GetMethod("hello").Invoke(ins, new[] { "blar" });
			Console.WriteLine(r);
		}
	}
}