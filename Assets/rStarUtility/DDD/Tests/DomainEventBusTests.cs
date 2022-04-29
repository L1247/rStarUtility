#region

using System.Collections.Generic;
using DDDTestFrameWork;
using MessagePipe;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.DDD.Implement.Core;
using rStarUtility.DDD.Implement.Derived;
using rStarUtility.DDD.Model;

#endregion

namespace rStartUtility.DDD.Tests
{
    [TestFixture]
    public class DomainEventBusTests : DIUnitTestFixture
    {
    #region Private Variables

        private ISubscriber<DomainEvent> subscriber;
        private IPublisher<DomainEvent>  publisher;
        private DomainEventBus           domainEventBus;

    #endregion

    #region Test Methods

        [Test]
        public void Post()
        {
            var domainEventImpl = new DomainEventImpl();
            domainEventBus.Post(domainEventImpl);
            publisher.Received(1).Publish(domainEventImpl);
        }

        [Test]
        public void PostAll_With_No_Event_Exist_In_Aggregate()
        {
            var aggregateRoot = Substitute.For<IAggregateRoot>();
            domainEventBus.PostAll(aggregateRoot);
            publisher.DidNotReceiveWithAnyArgs().Publish(null);
        }

        [Test]
        public void PostAll_With_Event_Exist_In_Aggregate()
        {
            var aggregateRoot   = Substitute.For<IAggregateRoot>();
            var domainEvents    = new List<DomainEvent>();
            var domainEventImpl = new DomainEventImpl();
            domainEvents.Add(domainEventImpl);
            aggregateRoot.GetDomainEvents().Returns(domainEvents);
            domainEventBus.PostAll(aggregateRoot);
            publisher.Received(1).Publish(domainEventImpl);
        }

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();
            subscriber     = Substitute.For<ISubscriber<DomainEvent>>();
            publisher      = Substitute.For<IPublisher<DomainEvent>>();
            domainEventBus = new DomainEventBus(subscriber , publisher);
        }

    #endregion
    }
}