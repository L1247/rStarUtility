#region

using NUnit.Framework;
using rStarUtility.DDD.DDDTestFrameWork;
using rStarUtility.DDD.Implement.Derived;

#endregion

namespace rStarUtility.Tests.DDD
{
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
}