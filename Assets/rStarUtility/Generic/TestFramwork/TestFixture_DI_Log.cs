#region

using NUnit.Framework;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class TestFixture_DI_Log : DIUnitTestFixture
    {
    #region Protected Variables

        protected MyStringWriter logOut;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            logOut = Given_A_Logger();
        }

    #endregion

    #region Public Methods

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            MyDebug.logEnabled = false;
        }

    #endregion

    #region Protected Methods

        protected void ShouldLog(string logMessage)
        {
            Assert.AreEqual(logMessage , logOut.GetString());
        }

    #endregion

    #region Private Methods

        private MyStringWriter Given_A_Logger()
        {
            var logOut = new MyStringWriter();
            MyDebug.SetOut(logOut);
            return logOut;
        }

    #endregion
    }
}