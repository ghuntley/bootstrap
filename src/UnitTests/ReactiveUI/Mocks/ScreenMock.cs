using PCLMock;

using ReactiveUI;

namespace ReactiveSearch.UnitTests.ReactiveUI.Mocks
{
    public sealed class ScreenMock : MockBase<IScreen>, IScreen
    {
        public RoutingState Router => this.Apply(x => x.Router);

        public ScreenMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
            if (behavior == MockBehavior.Loose)
            {
                this.ConfigureLooseBehavior();
            }
        }

        private void ConfigureLooseBehavior()
        {
            this
                .When(x => x.Router)
                .Return(new RoutingState());
        }
    }
}