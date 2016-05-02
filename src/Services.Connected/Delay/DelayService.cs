using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Services.Delay;
using ReactiveSearch.Utility;

namespace ReactiveSearch.Services.Connected.Delay
{
    public sealed class DelayService : IDelayService
    {
        private readonly IScheduler _scheduler;

        public DelayService(IScheduler scheduler)
        {
            Ensure.ArgumentNotNull(scheduler, nameof(scheduler));
            _scheduler = scheduler;
        }

        public IObservable<Unit> Delay(TimeSpan duration) =>
            Observable
                .Return(Unit.Default)
                .Delay(duration, _scheduler);
    }
}
