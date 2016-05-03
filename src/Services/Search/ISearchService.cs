using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Services.Api;

namespace ReactiveSearch.Services.Search
{
    public interface ISearchService
    {
        IObservable<IEnumerable<DuckDuckGoSearchResult>> Search(string query);
    }
}
