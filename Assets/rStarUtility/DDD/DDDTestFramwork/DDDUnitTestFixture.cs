#region

using System;
using rStarUtility.DDD.Event;
using Zenject;

#endregion

namespace DDDTestFrameWork
{
    public class DDDUnitTestFixture : DIUnitTestFixture
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

    #region Protected Methods

        protected void BindAsSingle<T>()
        {
            Container.Bind<T>().AsSingle();
        }

        protected void BindFromSubstitute<T>() where T : class
        {
            Container.Bind<T>().FromSubstitute();
        }

        protected string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        protected T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        protected Scenario Scenario(string annotation)
        {
            return new Scenario();
        }

    #endregion
    }
}