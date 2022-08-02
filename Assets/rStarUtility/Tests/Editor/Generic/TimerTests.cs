#region

using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.Implement.Derived;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class TimerTests : DIUnitTestFixture
{
#region Test Methods

    [Test]
    public void OnceCallBack()
    {
        BindFromSubstitute<ITimeProvider>();
        BindAsSingle<Timer>();
        var timeProvider = Resolve<ITimeProvider>();
        var timer        = Resolve<Timer>();
        timeProvider.GetDeltaTime().Returns(1);
        var result = false;
        timer.RegisterOnceCallBack(1 , () => result = true);
        timer.Tick();
        Assert.AreEqual(true , result ,      "result is not equal");
        Assert.AreEqual(0 ,    timer.Count , "Count is not equal");
    }

#endregion
}