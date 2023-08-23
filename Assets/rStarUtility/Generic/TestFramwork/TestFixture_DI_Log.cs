#region

using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Util;
using UnityEngine;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class TestFixture_DI_Log : DIUnitTestFixture
    {
    #region Protected Variables

        protected MyStringWriter logErrorOut;

        protected MyStringWriter logOut;

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            logOut      = new MyStringWriter();
            logErrorOut = new MyStringWriter();
            MyDebug.SetOut(logOut , logErrorOut);
        }

    #endregion

    #region Public Methods

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            MyDebug.logEnabled      = false;
            MyDebug.logErrorEnabled = false;
        }

    #endregion

    #region Protected Methods

        protected void ShouldContainLogError(string logMessage , bool contain = true)
        {
            MyDebug.logType.ShouldBe(LogType.Error);
            logErrorOut.GetString().Contains(logMessage).ShouldBe(contain);
        }

        protected void ShouldContainsLog(string logMessage , bool contain = true)
        {
            MyDebug.logType.ShouldBe(LogType.Log);
            logOut.GetString().Contains(logMessage).ShouldBe(contain);
        }

        protected void ShouldLog(string logMessage)
        {
            MyDebug.logType.ShouldBe(LogType.Log);
            logOut.GetStringAndClear().ShouldBe(logMessage);
        }

        protected void ShouldLogError(string logMessage)
        {
            MyDebug.logType.ShouldBe(LogType.Error);
            logErrorOut.GetStringAndClear().ShouldBe(logMessage);
        }

    #endregion
    }
}