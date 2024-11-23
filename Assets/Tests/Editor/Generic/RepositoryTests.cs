#region

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util;
using rStarUtility.Util.DDD.UseCase;
using rStarUtility.Util.Extensions.CSharp;
using TestObj_1 = TestObj;

#endregion

internal class RepositoryTests : DIUnitTestFixture
{
#region Private Variables

    private class TestObj : Entity
    {
    #region Constructor

        public TestObj(string id) : base(id) { }

    #endregion
    }

    private class TestObjRepository : Repository<TestObj>
    {
    #region Constructor

        public TestObjRepository(List<TestObj> entities) : base(entities) { }

    #endregion
    }

    private class TestObjRepository_OverrideValue : Repository<TestObj>
    {
    #region Protected Variables

        protected override bool overrideValue => true;

    #endregion

    #region Constructor

        public TestObjRepository_OverrideValue(List<TestObj> entities) : base(entities) { }

    #endregion
    }

    private          IRepository<TestObj> repository;
    private readonly string               id = "id";

#endregion

#region Setup/Teardown Methods

    [SetUp]
    public void SetUp()
    {
        repository = new TestObjRepository(new List<TestObj>());
    }

#endregion

#region Test Methods

    [Test(Description = "新增Entity")]
    public void Add()
    {
        var repo    = Bind_And_Resolve<TestObjRepository>();
        var testObj = new TestObj("TestObj");
        repo.Add(testObj);

        var succeed = repo.Add(testObj);
        Assert.AreEqual(false , succeed , "succeed is not equal");
        var entity = new TestObj("TestObjNew");
        succeed = repo.Add(entity);
        Assert.AreEqual(true , succeed , "succeed is not equal");
        var value = repo.Get("TestObjNew");
        Assert.AreEqual(entity , value , "value is not equal");
    }

    [Test]
    public void Add_With_Same_Id_And_Another_Entity()
    {
        repository = Bind_And_Resolve<TestObjRepository_OverrideValue>();
        AddWithNewTestObj();
        ShouldContainIs(true);
        var testObj = new TestObj(id);
        repository.Add(testObj);
        var foundObj = FindById();
        Assert.AreEqual(testObj , foundObj , "obj is not equal");
    }

    [Test]
    public void Add_With_Success()
    {
        AddWithNewTestObj();
        ShouldContainIs(true);
    }

    [Test]
    public void Bind_Entities_And_Resolve()
    {
        Bind_Instance(new List<TestObj>() { new TestObj(id) });
        Bind<TestObjRepository>();

        Resolve<TestObjRepository>().Count.ShouldBe(1);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public void Contain_Error_With_Invalid_Id(string id)
    {
        var exceptionMessage = "id can not be empty or null";
        ShouldExceptionThrown<PreconditionViolationException>(() => repository.Contains(id) , exceptionMessage);
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

        AddWithNewTestObj();

        ShouldContainIs(true);
    }

    [Test]
    public void DeleteAll()
    {
        AddWithNewTestObj();
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
        Container.Bind<TestObj>().AsSingle().WithArguments(id);
        Bind<TestObjRepository>();

        var success = Resolve<TestObjRepository>().Remove(id);

        Assert.AreEqual(true ,  success ,                                   "success is not equal");
        Assert.AreEqual(false , Resolve<TestObjRepository>().Contains(id) , "contain is not equal");
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
        var testObj = AddWithNewTestObj();

        var foundObj = FindById();

        Assert.NotNull(foundObj , "entity is null");
        Assert.AreEqual(testObj , foundObj , "obj is not equal");
    }

    [Test(Description = "取得物件，預設情境是一定會拿到，沒有拿到應出錯")]
    [TestCase(true ,  Description = "物件存在")]
    [TestCase(false , Description = "物件不存在，丟出錯誤")]
    public void Get_Entity(bool exist)
    {
        if (exist) Container.Bind<TestObj>().AsSingle().WithArguments(id);
        repository = Bind_And_Resolve<TestObjRepository>();

        if (exist.IsFalse())
        {
            ShouldExceptionThrown<KeyNotFoundException>(
                    () => repository.Get(id) , $"出錯了，{nameof(TestObjRepository)} - 找不到Id[{id}]的物件.");
        }
        else
        {
            var foundObj = repository.Get(id);
            ShouldContainIs(true);
            Assert.NotNull(foundObj , "entity is null");
        }
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

        AddWithNewTestObj();

        ShouldCount(1);
    }

    [Test]
    public void GetEntity_With_Exist()
    {
        ShouldContainIs(false);
        var testObj = AddWithNewTestObj();

        var optional = repository.Find(id);

        Assert.AreEqual(true ,    optional.Present , "exist is not equal");
        Assert.AreEqual(testObj , optional.Value ,   "aggregate is not equal");
    }

    [Test]
    public void GetEntity_With_NoExist()
    {
        ShouldContainIs(false);

        var optional = repository.Find(id);

        Assert.AreEqual(false , optional.Present , "exist is not equal");
        Assert.AreEqual(null ,  optional.Value ,   "aggregate is not equal");
    }

    [Test]
    public void GetKeys()
    {
        AddWithNewTestObj();
        var keys  = repository.Ids.ToList();
        var count = keys.Count;
        Assert.AreEqual(1 ,  count ,   "count is not equal");
        Assert.AreEqual(id , keys[0] , "key is not equal");
    }

    [Test]
    public void GetValueByKey()
    {
        var testObj = AddWithNewTestObj();
        var obj     = repository[id];

        Assert.NotNull(obj , "obj is null");
        Assert.AreEqual(obj , testObj , "obj is not equal");
    }

    [Test]
    public void GetValues()
    {
        AddWithNewTestObj();
        repository["sadsa"] = new TestObj(NewGuid());
        var keys  = repository.Entities.ToList();
        var count = keys.Count;
        Assert.AreEqual(2 , count , "count is not equal");
    }

    [Test]
    public void SetValueByKey()
    {
        AddWithNewTestObj();
        var testObj1 = new TestObj(id);
        repository[id] = testObj1;
        var obj = repository[id];

        Assert.NotNull(obj , "obj is null");
        Assert.AreEqual(obj , testObj1 , "obj is not equal");
    }

#endregion

#region Private Methods

    private TestObj AddWithNewTestObj()
    {
        var testObj = new TestObj(id);
        repository.Add(testObj);
        return testObj;
    }

    private TestObj FindById()
    {
        var optional = repository.Find(id);
        var testObj  = optional.Value;
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