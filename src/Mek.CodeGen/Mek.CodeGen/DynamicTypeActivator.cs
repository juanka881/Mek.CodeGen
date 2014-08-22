using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Mek.CodeGen
{
	public class DynamicTypeActivator
	{
		private Lazy<Func<object>> activator;

		public Type Type { get; set; }

		public DynamicTypeActivator(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			this.Type = type;
			this.activator = new Lazy<Func<object>>(this.GetActivator, LazyThreadSafetyMode.ExecutionAndPublication);
		}

		private Func<object> GetActivator()
		{
			var newExp = Expression.New(this.Type);
			var lambdaExp = Expression.Lambda<Func<object>>(newExp);
			var fn = lambdaExp.Compile();
			return fn;
		}

		public object GetInstance()
		{
			return this.activator.Value();
		}
	}
}