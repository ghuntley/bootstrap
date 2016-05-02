using System;
using System.Collections.Generic;
using System.Text;
using ReactiveSearch.App;
using ReactiveSearch.Services.iOS.Logging;
using Splat;

namespace ReactiveSearch.iOS
{
    public sealed class iOSCompositionRoot : CompositionRoot
    {
        protected override ILogger CreateLoggingService() => new LoggingService();
    }
}
