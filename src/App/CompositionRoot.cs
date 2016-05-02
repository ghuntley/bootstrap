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
        protected CompositionRoot()
        {
            _mainScheduler = new Lazy<IScheduler>(CreateMainScheduler);
            _taskPoolScheduler = new Lazy<IScheduler>(CreateTaskPoolScheduler);

            _blobCache = new Lazy<IBlobCache>(CreateBlobCache);
            _loggingService = new Lazy<ILogger>(CreateLoggingService);
            _stateService = new Lazy<IStateService>(CreateStateService);
        }
    }
}