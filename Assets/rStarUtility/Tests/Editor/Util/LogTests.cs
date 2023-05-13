#region

using NUnit.Framework;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Tests.Editor.Util
{
    public class LogTests : TestFixture_DI_Log
    {
    #region Test Methods

        [Test]
        public void LogMessage()
        {
            MyDebug.Log("123");
            Assert.AreEqual("123" , logOut.GetString());

            MyDebug.Log("456");
            Assert.AreEqual("456" , logOut.GetString());
        }

    #endregion
    }
}