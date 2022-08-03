#region

using System;
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
    private TimerSystem   timerSystem;

#endregion

#region Test Methods

    [Test]
    public void RegisterTimer()
    {
        timeProvider.GetDeltaTime().Returns(1);
        var result = false;
        timerSystem.RegisterOnceCallBack(id , 1 , () => result = true);
        timerSystem.Tick();
        Assert.AreEqual(true , result ,            "result is not equal");
        Assert.AreEqual(0 ,    timerSystem.Count , "Count is not equal");
    }

    [Test]
    public void RegisterTimer_Again_When_Callback()
    {
        timeProvider.GetDeltaTime().Returns(1);
        timerSystem.RegisterOnceCallBack(id , 1 , () => timerSystem.RegisterOnceCallBack(id , 1 , () => { }));
        ShouldNoExceptionThrown<Exception>(() => { timerSystem.Tick(); });
    }


    [Test]
    public void UnRegisterTimer()
    {
        timeProvider.GetDeltaTime().Returns(1);
        var result = false;
        timerSystem.RegisterOnceCallBack(id , 1 , () => result = true);
        timerSystem.UnRegisterOnceCallBack(id);
        Assert.AreEqual(0 , timerSystem.Count , "count is not equal");
        timerSystem.Tick();
        Assert.AreEqual(false , result , "result is not equal");
    }

#endregion

#region Public Methods

    public override void Setup()
    {
        base.Setup();
        BindFromSubstitute<ITimeProvider>();
        BindAsSingle<TimerSystem>();
        timeProvider = Resolve<ITimeProvider>();
        timerSystem  = Resolve<TimerSystem>();
    }

#endregion
}