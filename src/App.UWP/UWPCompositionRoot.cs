using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.App;
using ReactiveSearch.Services.UWP.Logging;
using Splat;

namespace App.UWP
{
    public class UWPCompositionRoot : CompositionRoot
    {
        protected override ILogger CreateLoggingService() => new LoggingService();
    }
}
