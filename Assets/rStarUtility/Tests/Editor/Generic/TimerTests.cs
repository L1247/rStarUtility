#region

using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.Implement.Derived;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class TimerTests : DIUnitTestFixture
{
#region Private Variables

    private ITimeProvider timeProvider;
    private TimerSystem   timer;

#endregion

#region Test Methods

    [Test]
    public void RegisterTimer()
    {
        timeProvider.GetDeltaTime().Returns(1);
        var result = false;
        timer.RegisterOnceCallBack(id , 1 , () => result = true);
        timer.Tick();
        Assert.AreEqual(true , result ,      "result is not equal");
        Assert.AreEqual(0 ,    timer.Count , "Count is not equal");
    }


    [Test]
    public void UnRegisterTimer() { }

#endregion

#region Public Methods

    public override void Setup()
    {
        base.Setup();
        BindFromSubstitute<ITimeProvider>();
        BindAsSingle<TimerSystem>();
        timeProvider = Resolve<ITimeProvider>();
        timer        = Resolve<TimerSystem>();
    }

#endregion
}