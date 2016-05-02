using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;
using ReactiveSearch.Utility;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveSearch.ViewModels
{
    public class SearchViewModel : ReactiveObject
    {
        private readonly ISearchService _searchService;

        public SearchViewModel(ISearchService searchService)
        {
            Ensure.ArgumentNotNull(searchService, nameof(searchService));
            _searchService = searchService;

            SearchResults = new ReactiveList<Unit>();

            // Here we're describing here, in a *declarative way*, the conditions in
            // which the Search command is enabled.  Now our Command IsEnabled is
            // perfectly efficient, because we're only updating the UI in the scenario
            // when it should change.
            var canSearch = this.WhenAnyValue(vm => vm.SearchQuery, value => !string.IsNullOrWhiteSpace(value));

            // ReactiveCommand has built-in support for background operations and
            // guarantees that this block will only run exactly once at a time, and
            // that the CanExecute will auto-disable and that property IsExecuting will
            // be set according whilst it is running.
            Search = ReactiveCommand.CreateAsyncTask(canSearch, async _ =>
            {
                //return await searchService.Search(SearchQuery);
            });

            // ReactiveCommands are themselves IObservables, whose value are the results
            // from the async method, guaranteed to arrive on the UI thread. We're going
            // to take the list of search results that the background operation loaded,
            // and them into our SearchResults.
            Search.Subscribe(results =>
            {
                //SearchResults.Clear();
                //SearchResults.AddRange(results);
            });

            // ThrownExceptions is any exception thrown from the CreateAsyncTask piped
            // to this Observable. Subscribing to this allows you to handle errors on
            // the UI thread.
            Search.ThrownExceptions
                .Subscribe(ex => {
                                     UserError.Throw("Potential Network Connectivity Error", ex);
                });

            // Whenever the Search query changes, we're going to wait for one second
            // of "dead airtime", then automatically invoke the subscribe command.
            this.WhenAnyValue(x => x.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
                .InvokeCommand(this, x => x.Search);
        }

        [Reactive]
        public string SearchQuery { get; set; }

        public ReactiveCommand<Unit> Search { get; private set; }

        public ReactiveCommand<Unit> OpenWebBrowser { get; private set; }

        public ReactiveList<Unit> SearchResults { get; private set; }
    }
}
