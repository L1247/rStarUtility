#region

using System;
using DDDCore.Event;
using DDDCore.Implement;
using MessagePipe;
using Zenject;

#endregion

namespace DDDTestFrameWork
{
    public class DDDUnitTestFixture : UnitTestFixture
    {
    #region Protected Variables

        protected IPublisher<DomainEvent> publisher;

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();
            Container.Bind<ISubscriber<DomainEvent>>().FromSubstitute();
            Container.Bind<IPublisher<DomainEvent>>().FromSubstitute();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            publisher = Container.Resolve<IPublisher<DomainEvent>>();
        }

    #endregion

    #region Protected Methods

        protected string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        protected Scenario Scenario(string annotation)
        {
            return new Scenario();
        }

    #endregion
    }
}