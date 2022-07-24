#region

using System;
using NUnit.Framework;

#endregion

namespace rStarUtility.DDD.DDDTestFrameWork
{
    public class SimpleTest
    {
    #region Protected Variables

        protected readonly int    number = 999;
        protected readonly string id     = "id";

    #endregion

    #region Protected Methods

        protected static void AssetException<T>(Action action , string expectedMessage) where T : Exception
        {
            var exception = Assert.Throws<T>(() => action());
            var message   = exception.Message;
            Assert.AreEqual(expectedMessage , message , "message is not equal");
        }

        protected string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

    #endregion
    }
}