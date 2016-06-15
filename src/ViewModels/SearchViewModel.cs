using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ReactiveSearch.Services.Api;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Services.Search;
using ReactiveSearch.Services.State;
using ReactiveSearch.Utility;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveSearch.ViewModels
{
    public class SearchViewModel : ReactiveObject, ISupportsActivation
    {
        private readonly INetworkConnectivityService _networkConnectivityService;
        private readonly ISearchService _searchService;

        public SearchViewModel(INetworkConnectivityService networkConnectivityService, ISearchService searchService)
        {
            Ensure.ArgumentNotNull(networkConnectivityService, nameof(networkConnectivityService));
            Ensure.ArgumentNotNull(searchService, nameof(searchService));

            _networkConnectivityService = networkConnectivityService;
            _searchService = searchService;

            SearchResults = new ReactiveList<DuckDuckGoSearchResult>();

            // Here we're describing here, in a *declarative way*, the conditions in
            // which the Search command is enabled.  Now our Command IsEnabled is
            // perfectly efficient, because we're only updating the UI in the scenario
            // when it should change.
            IObservable<bool> canSearch = this.WhenAnyValue(vm => vm.SearchQuery, value => !string.IsNullOrWhiteSpace(value));

            // ReactiveCommand has built-in support for background operations and
            // guarantees that this block will only run exactly once at a time, and
            // that the CanExecute will auto-disable and that property IsExecuting will
            // be set according whilst it is running.
            Search = ReactiveCommand.CreateFromObservable<DuckDuckGoSearchResult, DuckDuckGoSearchResult>(_ => _searchService.Search(SearchQuery), canSearch, RxApp.MainThreadScheduler);

            // ReactiveCommands are themselves IObservables, whose value are the results
            // from the async method, guaranteed to arrive on the given scheduler.
            // We're going to take the list of search results that the background
            // operation loaded, and them into our SearchResults.
            Search.Subscribe(searchResult =>
            {
                SearchResults.Clear();
                //SearchResults.AddRange(results);
            });

            // ThrownExceptions is any exception thrown from the CreateFromObservable piped
            // to this Observable. Subscribing to this allows you to handle errors on
            // the UI thread.
            Search.ThrownExceptions.Subscribe(ex => {
                //UserError.Throw("Potential Network Connectivity Error", ex);
            });

            this.WhenActivated(dispose =>
            {
                // Whenever the Search query changes, we're going to wait for one second
                // of "dead airtime", then automatically invoke the subscribe command.
                dispose(
                    this.WhenAnyValue(x => x.SearchQuery)
                        .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
                        .InvokeCommand(this, vm => vm.Search)
                );
            });
        }

        [Reactive]
        public string SearchQuery { get; set; }

        public ReactiveCommand<DuckDuckGoSearchResult, DuckDuckGoSearchResult> Search { get; private set; }

        public ReactiveList<DuckDuckGoSearchResult> SearchResults { get; private set; }

        ViewModelActivator ISupportsActivation.Activator { get; } = new ViewModelActivator();
    }
}
