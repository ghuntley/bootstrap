using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Core;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;
using ReactiveSearch.Utility;

namespace ReactiveSearch.Services.Connected.Search
{
    public class SearchService : ISearchService
    {
        private readonly IDuckDuckGoApiService _duckduckGoApiService;
        private readonly IStateService _stateService;

        public SearchService(IDuckDuckGoApiService duckDuckGoApiService, IStateService stateService)
        {
            Ensure.ArgumentNotNull(duckDuckGoApiService, nameof(duckDuckGoApiService));
            Ensure.ArgumentNotNull(stateService, nameof(stateService));

            _duckduckGoApiService = duckDuckGoApiService;
            _stateService = stateService;
        }
    }
}
