#region

#endregion

#region

using rStarUtility.Generic.Infrastructure;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class DIUnitTestFixture_With_EventBus : DIUnitTestFixture
    {
    #region Protected Variables

        protected IDomainEventBus domainEventBus;

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();
            BindFromSubstitute<IDomainEventBus>();
            domainEventBus = Resolve<IDomainEventBus>();
        }

    #endregion
    }
}