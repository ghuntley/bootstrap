using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using ReactiveSearch.Services.NetworkConnectivity;
using ReactiveSearch.Utility;

namespace ReactiveSearch.Services.Connected.NetworkConnectivity
{
    public class NetworkConnectivityService : DisposableBase, INetworkConnectivityService
    {
        public NetworkConnectivityService()
        {
            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }

        public IObservable<IEnumerable<ConnectionType>> Connectivity()
        {
            return Observable.Return(CrossConnectivity.Current.ConnectionTypes);
        }

        public IObservable<bool> IsInternetConnectivityAvailable()
        {
            throw new NotImplementedException();
        }

        public IObservable<bool> IsReachable(string host, int port = 80, int msTimeout = 5000)
        {
            return CrossConnectivity.Current.IsRemoteReachable(host, port, msTimeout).ToObservable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                CrossConnectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
            }
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {

        }
    }
}
