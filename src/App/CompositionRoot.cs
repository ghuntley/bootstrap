using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Akavache;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;

using Splat;

namespace ReactiveSearch.App
{
    public abstract partial class CompositionRoot
    {
        protected CompositionRoot()
        {
            _mainScheduler = new Lazy<IScheduler>(CreateMainScheduler);
            _taskPoolScheduler = new Lazy<IScheduler>(CreateTaskPoolScheduler);

            _loggingService = new Lazy<ILogger>(CreateLoggingService);
            _networkConnectivityService= new Lazy<INetworkConnectivityService>(CreateNetworkConnectivityService);
            _blobCache = new Lazy<IBlobCache>(CreateBlobCache);
            _stateService = new Lazy<IStateService>(CreateStateService);
            _duckDuckGoApiService = new Lazy<IDuckDuckGoApiService>(CreateDuckDuckGoApiService);
            _searchService = new Lazy<ISearchService>(CreateSearchService);
        }
    }
}