﻿using System;
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
        private readonly bool _enableRandomDelays;
        private readonly bool _enableRandomErrors;
        private readonly DuckDuckGoSearchResult _searchResult;

        public DuckDuckGoApiDisconnected(bool enableRandomDelays, bool enableRandomErrors)
        {
            _enableRandomDelays = enableRandomDelays;
            _enableRandomErrors = enableRandomErrors;
            _searchResult = JsonConvert.DeserializeObject<DuckDuckGoSearchResult>(DuckDuckGoApiDisconnectedResponses.Search);
        }

        public IObservable<DuckDuckGoSearchResult> Search(string query)
        {
            return Observable.Return(_searchResult)
                .ErrorWithProbabilityIf(_enableRandomErrors, 5)
                .DelayIf(_enableRandomDelays, 500, 1000);
        }
    }
}
