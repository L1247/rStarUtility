#region

using System;
using System.Linq;
using NUnit.Framework;
using rStarUtility.DDD.DDDTestFrameWork;
using rStarUtility.DDD.Implement.Abstract;

#endregion

namespace rStarUtility.Tests.DDD
{
    internal class GenericRepositoryTests : SimpleTest
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
            ShouldCount(1);

            repository.DeleteAll();

            ShouldCount(0);
        }

        [Test]
        public void GetAll()
        {
            var obj1 = new TestObj();
            var obj2 = new TestObj();
            repository.Save(GetGuid() , obj1);
            repository.Save(GetGuid() , obj2);
            ShouldCount(2);

            var aggregateRoots = repository.GetAll().ToList();

            Assert.AreEqual(obj1 , aggregateRoots[0] , "aggregate1 is not equal");
            Assert.AreEqual(obj2 , aggregateRoots[1] , "aggregate2 is not equal");
        }

        [Test]
        public void GetCount()
        {
            ShouldCount(0);

            SaveWithNewTestObj();

            ShouldCount(1);
        }

        [Test]
        public void Save_With_Success()
        {
            SaveWithNewTestObj();
            ShouldContainIs(true);
        }

        [Test]
        public void Save_With_Same_Id_And_Another_Entity()
        {
            SaveWithNewTestObj();
            var testObj = new TestObj();
            repository.Save(id , testObj);
            ShouldContainIs(true);
            var foundObj = FindById();
            Assert.AreEqual(testObj , foundObj , "obj is not equal");
        }


        [Test]
        [Ignore("allow same id")]
        public void Save_Error_With_Id_Exist()
        {
            SaveWithNewTestObj();
            AssetException<ArgumentException>(() => SaveWithNewTestObj() , $"the same key has already been added. key: {id}");
        }

        [Test]
        public void DeleteById_With_Success()
        {
            SaveWithNewTestObj();
            ShouldContainIs(true);

            var success = repository.DeleteById(id);

            Assert.AreEqual(true , success , "success is not equal");
            ShouldContainIs(false);
        }

        [Test]
        public void DeleteById_With_Fail()
        {
            var success = repository.DeleteById(id);

            Assert.AreEqual(false , success , "success is not equal");
            ShouldContainIs(false);
        }

        [Test]
        public void Contain_With_Success()
        {
            ShouldContainIs(false);

            SaveWithNewTestObj();

            ShouldContainIs(true);
        }

        [Test]
        public void Contain_With_No_Exist()
        {
            ShouldContainIs(false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Contain_Error_With_Invalid_Id(string id)
        {
            var exceptionMessage = "id is NullOrEmpty.";
            AssetException<ArgumentException>(() => repository.ContainsId(id) , exceptionMessage);
        }

        [Test]
        public void FindById_With_Empty_Repository()
        {
            Assert.IsNull(FindById() , "return is not null");
        }

        [Test]
        public void FindById_With_Success()
        {
            ShouldContainIs(false);
            var testObj = SaveWithNewTestObj();

            var foundObj = FindById();

            Assert.NotNull(foundObj , "entity is null");
            Assert.AreEqual(testObj , foundObj , "obj is not equal");
        }

        [Test]
        public void GetEntity_With_Exist()
        {
            ShouldContainIs(false);
            var testObj = SaveWithNewTestObj();

            var (exist , aggregateRoot) = repository.GetEntity(id);

            Assert.AreEqual(true ,    exist ,         "exist is not equal");
            Assert.AreEqual(testObj , aggregateRoot , "aggregate is not equal");
        }

        [Test]
        public void GetEntity_With_NoExist()
        {
            ShouldContainIs(false);

            var (exist , aggregateRoot) = repository.GetEntity(id);

            Assert.AreEqual(false , exist ,         "exist is not equal");
            Assert.AreEqual(null ,  aggregateRoot , "aggregate is not equal");
        }

    #endregion

    #region Private Methods

        private TestObj FindById()
        {
            return repository.FindById(id);
        }

        private TestObj SaveWithNewTestObj()
        {
            var testObj = new TestObj();
            repository.Save(id , testObj);
            return testObj;
        }

        private void ShouldContainIs(bool expectedContain)
        {
            Assert.AreEqual(expectedContain , repository.ContainsId(id) , "contain is not equal");
        }

        private void ShouldCount(int expectedCount)
        {
            Assert.AreEqual(expectedCount , repository.Count , "GetCount is not equal");
        }

    #endregion
    }
}