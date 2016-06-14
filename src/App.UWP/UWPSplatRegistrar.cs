using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.App;
using Splat;

namespace App.UWP
{
    public class UWPSplatRegistrar : SplatRegistrar
    {
        protected override void RegisterPlatformComponents(IMutableDependencyResolver splatLocator, CompositionRoot compositionRoot)
        {
            splatLocator.Register(compositionRoot.ResolveLoggingService, typeof(ILogger));
        }

        protected override void RegisterViews(IMutableDependencyResolver splatLocator)
        {
            throw new NotImplementedException();
        }
    }
}
