#region

using System.Linq;
using NUnit.Framework;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestExtensions;

#endregion

[TestFixture]
internal class GenericRepositoryTests
{
#region Test Methods

    [Test]
    public void Check_Add_New_Value()
    {
        var genericRepository = new GenericRepository<TestObj>();
        genericRepository.Contents.ToList().Add(new TestObj());
        genericRepository.Contents.Count.ShouldBe(0);
        genericRepository.Add(new TestObj());
    }

#endregion
}

internal class TestObj { }