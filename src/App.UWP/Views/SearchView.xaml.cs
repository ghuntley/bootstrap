﻿using ReactiveSearch.ViewModels;
using ReactiveUI;

namespace ReactiveSearch.App.UWP.Views
{
    public sealed partial class SearchView : IViewFor<SearchViewModel>
    {
        public SearchView()
        {
            this.InitializeComponent();

            this.WhenActivated(dispose =>
            {

            });
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SearchViewModel)value; }
        }

        public SearchViewModel ViewModel { get; set; }
    }
}
