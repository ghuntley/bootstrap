using System;
using System.Reactive;

namespace ReactiveSearch.Services.Delay
{
    public interface IDelayService
    {
        IObservable<Unit> Delay(TimeSpan duration);
    }
}