using ReactiveSearch.ViewModels;
using ReactiveUI;

namespace ReactiveSearch.App.UWP.Views
{
    public sealed partial class SearchResultView : IViewFor<SearchResultViewModel>
    {
        public SearchResultView()
        {
            this.InitializeComponent();

            this.WhenActivated(dispose =>
            {

            });
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SearchResultViewModel)value; }
        }

        public SearchResultViewModel ViewModel { get; set; }
    }
}
