#region

using System;
using NUnit.Framework;
using rStarUtility.DDD.DDDTestFrameWork;
using rStarUtility.DDD.Implement.Abstract;

#endregion

namespace rStarUtility.Tests.DDD
{
    class RepositoryTests : SimpleTest
    {
    #region Private Variables

        private class TestObj { }

        private GenericRepository<TestObj> repository;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public void SetUp()
        {
            repository = new GenericRepository<TestObj>();
        }

    #endregion

    #region Test Methods

        [Test]
        public void DeleteAll()
        {
            SaveWithNewTestObj();
            repository.DeleteAll();
            Assert.AreEqual(0 , repository.GetCount() , "count is not equal");
        }

        [Test]
        public void GetAll()
        {
            var obj1 = new TestObj();
            var obj2 = new TestObj();
            repository.Save(GetGuid() , obj1);
            repository.Save(GetGuid() , obj2);
            Assert.AreEqual(2 , repository.GetCount() , "count is not equal");
            var aggregateRoots = repository.GetAll();
            Assert.AreEqual(obj1 , aggregateRoots[0] , "aggregate1 is not equal");
            Assert.AreEqual(obj2 , aggregateRoots[1] , "aggregate2 is not equal");
        }

        [Test]
        public void GetCount()
        {
            Assert.AreEqual(0 , repository.GetCount() , "GetCount is not equal");
            SaveWithNewTestObj();
            Assert.AreEqual(1 , repository.GetCount() , "GetCount is not equal");
        }

        [Test]
        public void Save_With_Success()
        {
            SaveWithNewTestObj();
            Assert.AreEqual(true , repository.ContainsId(id) , "ContainsId is not equal");
        }

        [Test]
        public void Save_With_Fail()
        {
            SaveWithNewTestObj();
            var exception = Assert.Throws<ArgumentException>(() => SaveWithNewTestObj());
            var message   = exception.Message;
            Assert.AreEqual($"the same key has already been added. key: {id}" , message , "message is not equal");
        }

        [Test]
        public void DeleteById_With_Success()
        {
            SaveWithNewTestObj();
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
            SaveWithNewTestObj();
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
            var testObj  = SaveWithNewTestObj();
            var foundObj = repository.FindById(id);
            Assert.NotNull(foundObj , "entity is null");
            Assert.AreEqual(testObj , foundObj , "obj is not equal");
        }

        [Test]
        public void GetEntity_With_Exist()
        {
            var testObj = SaveWithNewTestObj();
            var (exist , aggregateRoot) = repository.GetEntity(id);
            Assert.AreEqual(true ,    exist ,         "exist is not equal");
            Assert.AreEqual(testObj , aggregateRoot , "aggregate is not equal");
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

        private TestObj SaveWithNewTestObj()
        {
            var testObj = new TestObj();
            repository.Save(id , testObj);
            return testObj;
        }

    #endregion
    }
}