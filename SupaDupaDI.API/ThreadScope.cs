using System;
using System.Collections.Generic;
using System.Text;

namespace SupaDupaDI.API
{
    public class ThreadScope : IDisposable
    {
        private object _scopeObject;
        public ThreadScope(object scopeObject)
        {
            _scopeObject = scopeObject;      
        }

        public void Dispose()
        {
            var disposableScopeObject = _scopeObject as IDisposable;
            disposableScopeObject.Dispose();
        }
    }
}
