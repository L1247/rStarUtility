#region

using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util.Helper;

#endregion

public class EasingHelperTests : DIUnitTestFixture
{
#region Test Methods

    [Test(Description = "測試線性曲線")]
    public void Test_Linear_Easing()
    {
        var easingFunction = EasingHelper.GetEasingFunction(EasingHelper.Ease.Linear);
        var value          = easingFunction.Invoke(0 , 1 , 0.5f);
        value.ShouldBe(0.5f);
        value = easingFunction.Invoke(0 , 1 , 1);
        value.ShouldBe(1);
    }

#endregion
}