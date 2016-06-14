using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Disconnected.Api
{
    public class DuckDuckGoApiDisconnected : IDuckDuckGoApi
    {
        private readonly bool _includeRandomDelays;
        private readonly bool _includeRandomErrors;
        private readonly DuckDuckGoSearchResult _searchResult;

        public DuckDuckGoApiDisconnected(bool includeRandomDelays, bool includeRandomErrors)
        {
            _includeRandomDelays = includeRandomDelays;
            _includeRandomErrors = includeRandomErrors;
            _searchResult = JsonConvert.DeserializeObject<DuckDuckGoSearchResult>(DuckDuckGoApiDisconnectedResponses.Search);
        }

        public IObservable<DuckDuckGoSearchResult> Search(string query)
        {
            return Observable.Return(_searchResult);
        }
    }
}
