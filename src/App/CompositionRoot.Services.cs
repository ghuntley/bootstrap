using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Connected.Api;
using ReactiveSearch.Services.Connected.NetworkConnectivity;
using ReactiveSearch.Services.Connected.Search;
using ReactiveSearch.Services.Connected.State;
using ReactiveSearch.Services.Disconnected.Api;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;
using Splat;

namespace ReactiveSearch.App
{
    public abstract partial class CompositionRoot
    {
        protected readonly Lazy<IBlobCache> _blobCache;
        protected readonly Lazy<IDuckDuckGoApiService> _duckDuckGoApiService;
        protected readonly Lazy<ILogger> _loggingService;
        protected readonly Lazy<INetworkConnectivityService> _networkConnectivityService;
        protected readonly Lazy<ISearchService> _searchService;
        protected readonly Lazy<IStateService> _stateService;
        public IDuckDuckGoApiService ResolveDuckDuckGoApiService() => _duckDuckGoApiService.Value;

        public ILogger ResolveLoggingService() => _loggingService.Value;
        public ISearchService ResolveSearchService() => _searchService.Value;

        public IStateService ResolveStateService() => _stateService.Value;
        protected abstract ILogger CreateLoggingService();

        private IBlobCache CreateBlobCache() => BlobCache.LocalMachine;

#if (DISCONNECTED || DISCONNECTED_ERRORS || DISCONNECTED_FAST)
        private IDuckDuckGoApiService CreateDuckDuckGoApiService() => new DuckDuckGoApiServiceDisconnected(
#if DISCONNECTED_FAST
            enableRandomDelays: false,
#else
            enableRandomDelays: true,
#endif
#if DISCONNECTED_ERRORS
            enableRandomErrors: true
#else
            enableRandomErrors: false
#endif        
        );
#else
        private IDuckDuckGoApiService CreateDuckDuckGoApiService() => new DuckDuckGoApiService();
#endif

        private INetworkConnectivityService CreateNetworkConnectivityService() => new NetworkConnectivityService();

        private ISearchService CreateSearchService()
                    => new SearchService(ResolveDuckDuckGoApiService(), ResolveStateService());

        private IStateService CreateStateService() => new StateService(ResolveBlobCache());
        private IBlobCache ResolveBlobCache() => _blobCache.Value;

        private INetworkConnectivityService ResolveNetworkConnectivityService() => _networkConnectivityService.Value;
    }
}
