using System;
using System.Reactive;

namespace ReactiveSearch.Services.State
{
    public delegate IObservable<Unit> SaveCallback(IStateService stateService);

    public interface IStateService
    {
        IObservable<T> Get<T>(string key);

        IObservable<Unit> Invalidate(string key);

        IDisposable RegisterSaveCallback(SaveCallback saveCallback);

        IObservable<Unit> Remove<T>(string key);

        IObservable<Unit> Save();

        IObservable<Unit> Set<T>(string key, T value);

        IObservable<Unit> Set<T>(string key, T value, TimeSpan expiration);
    }
}