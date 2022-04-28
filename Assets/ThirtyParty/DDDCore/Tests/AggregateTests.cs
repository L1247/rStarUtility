#region

using DDDCore.Implement;
using DDDTestFramework;
using NUnit.Framework;

#endregion

namespace ThirtyParty.DDDCore.Tests
{
    public class AggregateTests : SimpleTest
    {
    #region Test Methods

        [Test]
        public void GetId()
        {
            var aggregateRoot = new AggregateRootImpl(id);
            Assert.AreEqual(id , aggregateRoot.GetId() , "id is not equal");
        }

    #endregion
    }
}