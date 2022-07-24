#region

using NUnit.Framework;
using rStarUtility.Generic.Implement.Derived;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class AbstractRepositoryTest : SimpleTest
{
#region Test Methods

    [Test]
    public void Save()
    {
        var repository = new RepositoryImpl();
        repository.Save(new AggregateRootImpl(id));
        Assert.AreEqual(true , repository.ContainsId(id) , "ContainsId is not equal");
    }

#endregion
}