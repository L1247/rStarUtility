#region

using NUnit.Framework;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util;

#endregion

public class LogTests : TestFixture_DI_Log
{
#region Test Methods

    [Test]
    public void LogErrorMessage()
    {
        MyDebug.Log("123");
        ShouldLog("123");

        MyDebug.LogError("456");
        ShouldLogError("456");
    }

    [Test]
    public void LogMessage()
    {
        MyDebug.Log("123");
        ShouldLog("123");

        MyDebug.Log("456");
        ShouldLog("456");
    }

#endregion
}