#region

using System;
using System.Linq;
using NUnit.Framework;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestFrameWork;

#endregion

internal class RepositoryTests : SimpleTest
{
#region Private Variables

    private class TestObj : Entity
    {
    #region Constructor

        public TestObj(string id) : base(id) { }

    #endregion
    }

    private class TestObjRepository : Repository<TestObj> { }

    private          TestObjRepository repository;
    private readonly string            id = "id";

#endregion

#region Setup/Teardown Methods

    [SetUp]
    public void SetUp()
    {
        repository = new TestObjRepository();
    }

#endregion

#region Test Methods

    [Test]
    public void Add()
    {
        var repo    = new Repository<TestObj>();
        var testObj = new TestObj("TestObj");
        repo.Add(testObj);

        var succeed = repo.Add(testObj);
        Assert.AreEqual(false , succeed , "succeed is not equal");
        var entity = new TestObj("TestObjNew");
        succeed = repo.Add(entity);
        Assert.AreEqual(true , succeed , "succeed is not equal");
        var value = repo.Find("TestObjNew").Value;
        Assert.AreEqual(entity , value , "value is not equal");
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public void Contain_Error_With_Invalid_Id(string id)
    {
        var exceptionMessage = "id is NullOrEmpty.";
        ShouldExceptionThrown<ArgumentException>(() => repository.Contains(id) , exceptionMessage);
    }

    [Test]
    public void Contain_With_No_Exist()
    {
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
    public void DeleteAll()
    {
        SaveWithNewTestObj();
        ShouldCount(1);

        repository.RemoveAll();

        ShouldCount(0);
    }

    [Test]
    public void DeleteById_With_Fail()
    {
        var success = repository.Remove(id);

        Assert.AreEqual(false , success , "success is not equal");
        ShouldContainIs(false);
    }

    [Test]
    public void DeleteById_With_Success()
    {
        SaveWithNewTestObj();
        ShouldContainIs(true);

        var success = repository.Remove(id);

        Assert.AreEqual(true , success , "success is not equal");
        ShouldContainIs(false);
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
    public void GetAll()
    {
        var obj1 = new TestObj(NewGuid());
        var obj2 = new TestObj(NewGuid());
        repository.Add(obj1);
        repository.Add(obj2);
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
    public void GetEntity_With_Exist()
    {
        ShouldContainIs(false);
        var testObj = SaveWithNewTestObj();

        var optional = repository.Find(id);

        Assert.AreEqual(true , optional.Present , "exist is not equal");
        Assert.AreEqual(testObj , optional.Value , "aggregate is not equal");
    }

    [Test]
    public void GetEntity_With_NoExist()
    {
        ShouldContainIs(false);

        var optional = repository.Find(id);

        Assert.AreEqual(false , optional.Present , "exist is not equal");
        Assert.AreEqual(null , optional.Value , "aggregate is not equal");
    }

    [Test]
    public void GetKeys()
    {
        SaveWithNewTestObj();
        var keys  = repository.Ids.ToList();
        var count = keys.Count;
        Assert.AreEqual(1 , count , "count is not equal");
        Assert.AreEqual(id , keys[0] , "key is not equal");
    }

    [Test]
    public void GetValueByKey()
    {
        var testObj = SaveWithNewTestObj();
        var obj     = repository[id];

        Assert.NotNull(obj , "obj is null");
        Assert.AreEqual(obj , testObj , "obj is not equal");
    }

    [Test]
    public void GetValues()
    {
        SaveWithNewTestObj();
        repository["sadsa"] = new TestObj(NewGuid());
        var keys  = repository.Entities.ToList();
        var count = keys.Count;
        Assert.AreEqual(2 , count , "count is not equal");
    }

    [Test]
    public void Save_With_Same_Id_And_Another_Entity()
    {
        SaveWithNewTestObj();
        ShouldContainIs(true);
        var testObj = new TestObj(id);
        repository.Add(testObj);
        var foundObj = FindById();
        Assert.AreNotEqual(testObj , foundObj , "obj is equal");
        repository.Add(testObj , true);
        foundObj = FindById();
        Assert.AreEqual(testObj , foundObj , "obj is not equal");
    }

    [Test]
    public void Save_With_Success()
    {
        SaveWithNewTestObj();
        ShouldContainIs(true);
    }

    [Test]
    public void SetValueByKey()
    {
        SaveWithNewTestObj();
        var testObj1 = new TestObj(id);
        repository[id] = testObj1;
        var obj = repository[id];

        Assert.NotNull(obj , "obj is null");
        Assert.AreEqual(obj , testObj1 , "obj is not equal");
    }

#endregion

#region Private Methods

    private TestObj FindById()
    {
        var optional = repository.Find(id);
        var testObj  = optional.Value;
        return testObj;
    }

    private TestObj SaveWithNewTestObj()
    {
        var testObj = new TestObj(id);
        repository.Add(testObj);
        return testObj;
    }

    private void ShouldContainIs(bool expectedContain)
    {
        Assert.AreEqual(expectedContain , repository.Contains(id) , "contain is not equal");
    }

    private void ShouldCount(int expectedCount)
    {
        Assert.AreEqual(expectedCount , repository.Count , "GetCount is not equal");
    }

#endregion
}