using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using ReactiveSearch.Services.State;
using Splat;

namespace ReactiveSearch.App
{
    public abstract partial class CompositionRoot
    {
        protected readonly Lazy<IScheduler> _mainScheduler;
        protected readonly Lazy<IScheduler> _taskPoolScheduler;


        private IScheduler CreateMainScheduler() => new SynchronizationContextScheduler(SynchronizationContext.Current);
        private IScheduler CreateTaskPoolScheduler() => TaskPoolScheduler.Default;
    }
}
