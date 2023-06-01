#region

using NUnit.Framework;
using rStarUtility.Util;
using UnityEngine;

#endregion

[TestFixture]
public class UnityPathUtilityTests
{
#region Test Methods

    [Test]
    public void GetDataPathWithoutAssets()
    {
        var dataPathWithoutAssets = UnityPathUtility.GetDataPathWithoutAssets();
        var dataPath              = Application.dataPath.Replace("/Assets" , string.Empty);
        Assert.AreEqual(dataPath , dataPathWithoutAssets);
    }

    [Test]
    public void GetPackageAssetPath()
    {
        var packageAssetPath = UnityPathUtility.GetPackageAssetPath("2D Sprite");
        Assert.AreEqual("Packages/com.unity.2d.sprite" , packageAssetPath);
    }

    [Test]
    public void GetPackageName()
    {
        var packageName = UnityPathUtility.GetPackageName("2D Sprite");
        Assert.AreEqual("com.unity.2d.sprite" , packageName);
    }

    [Test]
    public void ReplaceStringForForwardSlash()
    {
        var path = "C:\\Users\\User\\AppData\\LocalLow\\rStar\\rStarUtility";
        path = path.ReplaceStringForForwardSlash();
        Assert.AreEqual("C:/Users/User/AppData/LocalLow/rStar/rStarUtility" , path);
    }

    [Test]
    public void ResolvingAbsolutePath()
    {
        var resolvingAbsolutePath = UnityPathUtility.ResolvingAbsolutePath("2D Sprite");
        Assert.AreEqual(UnityPathUtility.GetDataPathWithoutAssets() + "/Library/PackageCache/com.unity.2d.sprite@1.0.0" ,
                        resolvingAbsolutePath);
    }

#endregion
}