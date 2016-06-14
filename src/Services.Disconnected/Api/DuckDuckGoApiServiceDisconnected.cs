using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Disconnected.Api
{
    public class DuckDuckGoApiServiceDisconnected : IDuckDuckGoApiService
    {
        private readonly IDuckDuckGoApi _duckDuckGoApi;

        public DuckDuckGoApiServiceDisconnected(bool includeRandomDelays, bool includeRandomErrors)
        {
            _duckDuckGoApi = new DuckDuckGoApiDisconnected(includeRandomDelays, includeRandomErrors);
        }

        public IDuckDuckGoApi Background => _duckDuckGoApi;
        public IDuckDuckGoApi Speculative => _duckDuckGoApi;
        public IDuckDuckGoApi UserInitiated => _duckDuckGoApi;
    }
}
