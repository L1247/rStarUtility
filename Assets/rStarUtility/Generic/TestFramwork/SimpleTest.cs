#region

using System;
using NUnit.Framework;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class SimpleTest
    {
    #region Protected Methods

        protected string NewGuid()
        {
            return Ulid.NewUlid().ToString();
        }

        protected Scenario Scenario(string annotation)
        {
            return new Scenario();
        }

        protected void ShouldExceptionThrown<T>(Action action , string expectedMessage) where T : Exception
        {
            var exception = Assert.Throws<T>(() => action());
            var message   = exception.Message;
            Assert.AreEqual(expectedMessage , message , "message is not equal");
        }

        protected void ShouldNoExceptionThrown<T>(Action action) where T : Exception
        {
            AssertEx.NoExceptionThrown<T>(action.Invoke);
        }

    #endregion
    }
}