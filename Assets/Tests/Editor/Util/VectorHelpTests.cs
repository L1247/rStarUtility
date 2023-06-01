#region

using NUnit.Framework;
using rStarUtility.Util.Helper;
using UnityEngine;

#endregion

public class VectorHelpTests
{
#region Test Methods

    [Test]
    [TestCase(0F , true)]
    [TestCase(1F , false)]
    public void IsCloseThePoint(float y , bool expectedIsCloseThePoint)
    {
        var point1            = new Vector2(2 , y);
        var point2            = new Vector2(1 , 0);
        var isCloseThePointV2 = VectorHelper.IsCloseThePoint(point1 , point2 , 1f);
        Assert.AreEqual(expectedIsCloseThePoint , isCloseThePointV2 , "isCloseThePointV2 is not equal");
    }

#endregion
}