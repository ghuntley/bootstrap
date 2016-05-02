using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using ReactiveSearch.Services.Connected.State;
using ReactiveSearch.Services.State;
using Splat;

namespace ReactiveSearch.App
{
    public abstract partial class CompositionRoot
    {
        protected readonly Lazy<IBlobCache> _blobCache;
        protected readonly Lazy<ILogger> _loggingService;
        protected readonly Lazy<IStateService> _stateService;


        public ILogger ResolveLoggingService() => _loggingService.Value;
        public IStateService ResolveStateService() => _stateService.Value;
        private IStateService CreateStateService() => new StateService(_blobCache.Value);

        protected abstract ILogger CreateLoggingService();

        private IBlobCache CreateBlobCache() => BlobCache.LocalMachine;
    }
}
