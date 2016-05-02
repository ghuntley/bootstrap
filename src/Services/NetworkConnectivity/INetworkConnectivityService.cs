using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;

namespace ReactiveSearch.Services.NetworkConnectivity
{
    public interface INetworkConnectivityService
    {
        IObservable<bool> IsInternetConnectivityAvailable();
        IObservable<bool> IsReachable(string host, int port = 80, int msTimeout = 5000);
        IObservable<IEnumerable<ConnectionType>> InternetConnectivity();
    }
}
