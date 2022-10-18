using System;

namespace Depra.Random.Application.System.Proxy
{
    internal abstract class DisposableSystemRandomProxy : SystemRandomProxy, IDisposable
    {
        public abstract void Dispose();

        protected DisposableSystemRandomProxy(global::System.Random random) : base(random) { }
    }
}