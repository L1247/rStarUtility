#region

using System.Linq;
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
        repository.Add(Create_Entity(id)).ShouldTrue();
        repository.Count.ShouldBe(1);
    }

    [Test(Description = "新增相同ID Entity")]
    public void _02_Add_Same_Entity()
    {
        repository.Add(Create_Entity(id)).ShouldTrue();
        repository.Add(Create_Entity(id)).ShouldTrue();
        repository.Count.ShouldBe(1);
    }

    [Test(Description = "取得repository數量，使用不同或相同Id")]
    public void _03_Get_Count()
    {
        repository.Add(Create_Entity("1")).ShouldBe(true);
        repository.Add(Create_Entity("1")).ShouldBe(true);
        repository.Count.ShouldBe(1);
        repository.Add(Create_Entity("2")).ShouldBe(true);
        repository.Count.ShouldBe(2);
    }

    [Test(Description = "取得相同ID的陣列")]
    public void _04_Get_All()
    {
        repository.Add(Create_Entity("1")).ShouldTrue();
        repository.Add(Create_Entity("1")).ShouldTrue();
        repository.Get_All("1").Count().ShouldBe(2);
        repository.Get_All("2").Count().ShouldBe(0);
    }

    [Test(Description = "使用ID，移除Entities")]
    public void _05_Remove()
    {
        repository.Add(Create_Entity("1")).ShouldTrue();
        repository.Add(Create_Entity("1")).ShouldTrue();
        repository.Remove("1").ShouldTrue();
        repository.Count.ShouldBe(0);
    }

#endregion

#region Private Methods

    private TestEntity Create_Entity(string id)
    {
        return new TestEntity(id);
    }

#endregion
}