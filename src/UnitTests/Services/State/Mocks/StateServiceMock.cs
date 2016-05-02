using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

using ReactiveSearch.Services.State;

using PCLMock;

namespace ReactiveSearch.UnitTests.Services.State.Mocks
{
    public sealed partial class StateServiceMock
    {
partial         void ConfigureLooseBehavior()
        {
            this
                .When(x => x.Save())
                .Return(Observable.Return(Unit.Default));
            this
                .When(x => x.RegisterSaveCallback(It.IsAny<SaveCallback>()))
                .Return(Disposable.Empty);
        }
    }
}