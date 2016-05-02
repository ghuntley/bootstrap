using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveSearch.Services.Api
{
    public interface IDuckDuckGoApiService
    {
        IDuckDuckGoApi Background { get; }
        IDuckDuckGoApi Speculative { get; }
        IDuckDuckGoApi UserInitiated { get; }
    }
}
