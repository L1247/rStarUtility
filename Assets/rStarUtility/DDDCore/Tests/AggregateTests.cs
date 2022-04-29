#region

using System.Linq;
using DDDTestFramework;
using NUnit.Framework;
using rStarUtility.DDDCore.Implement.Derived;

#endregion

namespace rStartUtility.DDDCore.Tests
{
    public class AggregateTests : SimpleTest
    {
    #region Private Variables

        private AggregateRootImpl aggregateRoot;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void SetUp()
        {
            var aggregateRoot1 = new AggregateRootImpl(id);
            aggregateRoot = aggregateRoot1;
        }

    #endregion

    #region Test Methods

        [Test]
        public void GetId()
        {
            Assert.AreEqual(id , aggregateRoot.GetId() , "id is not equal");
        }

        [Test]
        public void GetDomainEvents()
        {
            Assert.AreEqual(0 , aggregateRoot.GetDomainEvents().Count , "count is not equal");
        }

        [Test]
        public void AddDomainEvent()
        {
            aggregateRoot.AddDomainEvent(new DomainEventImpl());
            Assert.AreEqual(1 , aggregateRoot.GetDomainEvents().Count , "count is not equal");
        }

        [Test]
        public void FindDomainEvent_With_Exist()
        {
            aggregateRoot.AddDomainEvent(new DomainEventImpl());
            Assert.NotNull(aggregateRoot.FindDomainEvent<DomainEventImpl>() , "DomainEventImpl is null");
        }

        [Test]
        public void FindDomainEvent_With_NoExist()
        {
            Assert.IsNull(aggregateRoot.FindDomainEvent<DomainEventImpl>() , "DomainEventImpl is null");
        }

        [Test]
        public void FindDomainEvents()
        {
            var domainEventImpl1 = new DomainEventImpl();
            var domainEventImpl2 = new DomainEventImpl();
            aggregateRoot.AddDomainEvent(domainEventImpl1);
            aggregateRoot.AddDomainEvent(domainEventImpl2);
            var findDomainEvents = aggregateRoot.FindDomainEvents<DomainEventImpl>().ToList();
            Assert.AreEqual(2 ,                findDomainEvents.Count , "count is not equal");
            Assert.AreEqual(domainEventImpl1 , findDomainEvents[0] ,    "domainEvent is not equal");
            Assert.AreEqual(domainEventImpl2 , findDomainEvents[1] ,    "domainEvent is not equal");
        }

        [Test]
        public void ClearDomainEvent()
        {
            aggregateRoot.AddDomainEvent(new DomainEventImpl());
            Assert.AreEqual(1 , aggregateRoot.GetDomainEvents().Count , "count is not equal");
            aggregateRoot.ClearDomainEvents();
            Assert.AreEqual(0 , aggregateRoot.GetDomainEvents().Count , "count is not equal");
        }

    #endregion
    }
}