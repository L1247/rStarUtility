#region

using DDDCore.Implement;
using DDDTestFrameWork;
using NUnit.Framework;

#endregion

namespace ThirtyParty.DDDCore.Tests
{
    public class RepositoryTests : DDDUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void GetAll_When_Delete()
        {
            var id             = NewGuid();
            var repositoryImpl = new RepositoryImpl<AggregateRoot>();
            repositoryImpl.Save(new AggregateRootImpl(id));

            Assert.AreEqual(1 , repositoryImpl.GetAll().Count , "count is not equal");
            repositoryImpl.DeleteById(id);
            Assert.AreEqual(false , repositoryImpl.ContainsId(id) , "contains is not equal");
            Assert.AreEqual(0 ,     repositoryImpl.GetAll().Count , "count is not equal");
        }

        [Test]
        public void FindById_With_Empty_Repository()
        {
            var repositoryImpl = new RepositoryImpl<AggregateRoot>();
            Assert.IsNull(repositoryImpl.FindById(NewGuid()) , "return is null");
        }

    #endregion
    }
}