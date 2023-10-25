#region

using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util.Managers;

#endregion

namespace rStarUtility.Generic.Tests.Tests.Editor.Generic
{
    public class RegistryTests : DIUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void _01_Count_With_Bind()
        {
            Bind<TestObj>();
            Bind<Registry<TestObj>>();

            var registry = Resolve<Registry<TestObj>>();
            registry.Count.ShouldBe(1);
        }

    #endregion
    }
}