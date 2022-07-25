#region

using System;
using NUnit.Framework;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class SimpleTest
    {
    #region Protected Variables

        protected readonly int    number = 999;
        protected readonly string id     = "id";

    #endregion

    #region Protected Methods

        protected void AssetException<T>(Action action , string expectedMessage) where T : Exception
        {
            var exception = Assert.Throws<T>(() => action());
            var message   = exception.Message;
            Assert.AreEqual(expectedMessage , message , "message is not equal");
        }

        protected string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        protected Scenario Scenario(string annotation)
        {
            return new Scenario();
        }

    #endregion
    }
}