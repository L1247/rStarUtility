#region

using NUnit.Framework;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class ListRepositoryTest : DIUnitTestFixture
{
#region Private Variables

    private class TestEntity : IEntity<string>
    {
    #region Public Variables

        public string Id { get; }

    #endregion

    #region Constructor

        public TestEntity(string id)
        {
            Id = id;
        }

    #endregion
    }

    private const string                     id = "Id";
    private       ListRepository<TestEntity> repository;

#endregion

#region Setup/Teardown Methods

    [SetUp]
    public void SetUp()
    {
        repository = new ListRepository<TestEntity>();
    }

#endregion

#region Test Methods

    [Test(Description = "新增Entity")]
    public void _01_Add()
    {
        repository.Add(new TestEntity(id)).ShouldBe(true);
        repository.Count.ShouldBe(1);
    }

    [Test(Description = "新增相同ID Entity")]
    public void _02_Add_Same_Entity()
    {
        repository.Add(new TestEntity(id)).ShouldBe(true);
        repository.Add(new TestEntity(id)).ShouldBe(true);
        repository.Count.ShouldBe(2);
    }

    [Test(Description = "測試數量，使用不同或相同Id")]
    public void _03_Test_Count()
    {
        repository.Add(new TestEntity("1")).ShouldBe(true);
        repository.Add(new TestEntity("1")).ShouldBe(true);
        repository.Count.ShouldBe(1);
        repository.Add(new TestEntity("2")).ShouldBe(true);
        repository.Count.ShouldBe(2);
    }

#endregion
}