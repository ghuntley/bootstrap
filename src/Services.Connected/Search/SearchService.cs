using ReactiveSearch.Core;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;
using ReactiveSearch.Utility;
using System;
using System.Reactive.Linq;

namespace ReactiveSearch.Services.Connected.Search
{
    public class SearchService : ISearchService
    {
        private readonly IDuckDuckGoApiService _duckDuckGoApiService;
        private readonly IStateService _stateService;

        public SearchService(IDuckDuckGoApiService duckDuckGoApiService, IStateService stateService)
        {
            Ensure.ArgumentNotNull(duckDuckGoApiService, nameof(duckDuckGoApiService));
            Ensure.ArgumentNotNull(stateService, nameof(stateService));

            _duckDuckGoApiService = duckDuckGoApiService;
            _stateService = stateService;
        }

        public IObservable<DuckDuckGoSearchResult> Search(string query)
        {
            return _stateService.GetOrFetch(BlobCacheKeys.GetKeyForSearch(query),
                async () => await _duckDuckGoApiService.UserInitiated.Search(query), absoluteExpiration: DateTime.UtcNow.AddDays(7));
        }
    }
}