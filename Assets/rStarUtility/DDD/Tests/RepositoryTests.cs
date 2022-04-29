#region

using System;
using DDDTestFramework;
using NUnit.Framework;
using rStarUtility.DDD.Implement.Core;
using rStarUtility.DDD.Implement.Derived;

#endregion

namespace rStartUtility.DDD.Tests
{
    public class RepositoryTests : SimpleTest
    {
    #region Private Variables

        private RepositoryImpl<AggregateRoot> repository;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void SetUp()
        {
            repository = new RepositoryImpl<AggregateRoot>();
        }

    #endregion

    #region Test Methods

        [Test]
        public void DeleteAll()
        {
            repository.Save(GetNewAggregate());
            repository.DeleteAll();
            Assert.AreEqual(0 , repository.GetCount() , "count is not equal");
        }

        [Test]
        public void GetAll()
        {
            var aggregate1 = GetNewAggregate();
            var aggregate2 = new AggregateRootImpl(GetGuid());
            repository.Save(aggregate1);
            repository.Save(aggregate2);
            Assert.AreEqual(2 , repository.GetCount() , "count is not equal");
            var aggregateRoots = repository.GetAll();
            Assert.AreEqual(aggregate1 , aggregateRoots[0] , "aggregate1 is not equal");
            Assert.AreEqual(aggregate2 , aggregateRoots[1] , "aggregate2 is not equal");
        }

        [Test]
        public void GetCount()
        {
            Assert.AreEqual(0 , repository.GetCount() , "GetCount is not equal");
            repository.Save(GetNewAggregate());
            Assert.AreEqual(1 , repository.GetCount() , "GetCount is not equal");
        }

        [Test]
        public void Save_With_Success()
        {
            repository.Save(GetNewAggregate());
            Assert.AreEqual(true , repository.ContainsId(id) , "ContainsId is not equal");
        }

        [Test]
        public void Save_With_Fail()
        {
            repository.Save(GetNewAggregate());
            var exception = Assert.Throws<ArgumentException>(() => repository.Save(GetNewAggregate()));
            var message   = exception.Message;
            Assert.AreEqual($"the same key has already been added. key: {id}" , message , "message is not equal");
        }

        [Test]
        public void DeleteById_With_Success()
        {
            repository.Save(GetNewAggregate());
            var success = repository.DeleteById(id);
            Assert.AreEqual(true ,  success ,                   "success is not equal");
            Assert.AreEqual(false , repository.ContainsId(id) , "contains is not equal");
        }

        [Test]
        public void DeleteById_With_Fail()
        {
            var success = repository.DeleteById(id);
            Assert.AreEqual(false , success ,                   "success is not equal");
            Assert.AreEqual(false , repository.ContainsId(id) , "contains is not equal");
        }

        [Test]
        public void Contain_With_Success()
        {
            repository.Save(GetNewAggregate());
            Assert.AreEqual(true , repository.ContainsId(id) , "id is not equal");
        }

        [Test]
        public void Contain_With_Fail()
        {
            Assert.AreEqual(false , repository.ContainsId(id) , "id is not equal");
        }


        [Test]
        public void FindById_With_Empty_Repository()
        {
            Assert.IsNull(repository.FindById(id) , "return is not null");
        }

        [Test]
        public void FindById_With_Success()
        {
            var aggregate = GetNewAggregate();
            repository.Save(aggregate);
            Assert.AreEqual(aggregate , repository.FindById(id) , "aggregate is not equal");
        }

        [Test]
        public void GetEntity_With_Exist()
        {
            var aggregate = GetNewAggregate();
            repository.Save(aggregate);
            var (exist , aggregateRoot) = repository.GetEntity(id);
            Assert.AreEqual(true ,      exist ,         "exist is not equal");
            Assert.AreEqual(aggregate , aggregateRoot , "aggregate is not equal");
        }

        [Test]
        public void GetEntity_With_NoExist()
        {
            var (exist , aggregateRoot) = repository.GetEntity(id);
            Assert.AreEqual(false , exist ,         "exist is not equal");
            Assert.AreEqual(null ,  aggregateRoot , "aggregate is not equal");
        }

    #endregion

    #region Private Methods

        private AggregateRootImpl GetNewAggregate()
        {
            return new AggregateRootImpl(id);
        }

    #endregion
    }
}