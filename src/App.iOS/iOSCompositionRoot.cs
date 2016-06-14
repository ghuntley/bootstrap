using ReactiveSearch.Services.iOS.Logging;
using Splat;

namespace ReactiveSearch.App.iOS
{
    public sealed class iOSCompositionRoot : CompositionRoot
    {
        protected override ILogger CreateLoggingService() => new LoggingService();
    }
}
