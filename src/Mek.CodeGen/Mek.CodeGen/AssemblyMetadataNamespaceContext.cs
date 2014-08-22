using System;
using System.Collections.Generic;
using System.Linq;

namespace Mek.CodeGen
{
	public class AssemblyMetadataNamespaceContext : IDisposable
	{
		private readonly Action onDisposed;

		public AssemblyMetadataNamespaceContext(Action onDisposed)
		{
			if(onDisposed == null)
				throw new ArgumentNullException("onDisposed");

			this.onDisposed = onDisposed;
		}

		public void Dispose()
		{
			this.onDisposed();
		}
	}
}