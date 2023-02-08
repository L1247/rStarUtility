#region

using System.IO;
using NUnit.Framework;
using rStarUtility.Util.Editor;
using UnityEngine;

#endregion

[TestFixture]
public class CustomEditorUtilityTests
{
#region Private Variables

    private const string overrideControllerFolderPath = "ForUT/AnimatorOverrider";

#endregion

#region Test Methods

    [Test]
    [TestCase(SearchOption.TopDirectoryOnly , false)]
    [TestCase(SearchOption.AllDirectories , true)]
    public void GetObjectAtPath(SearchOption searchOption , bool expectedIsExist)
    {
        var animatorOverrideController =
                CustomEditorUtility.GetObjectAtPath<AnimatorOverrideController>(overrideControllerFolderPath , searchOption);
        var isExist = animatorOverrideController is not null;
        Assert.AreEqual(expectedIsExist , isExist);
    }

    [Test]
    [TestCase(SearchOption.TopDirectoryOnly , 0)]
    [TestCase(SearchOption.AllDirectories , 2)]
    public void GetObjectsAtPath(SearchOption searchOption , int expectedOverriderControllerCount)
    {
        var animatorOverrideControllers =
                CustomEditorUtility.GetObjectsAtPath<AnimatorOverrideController>(overrideControllerFolderPath , searchOption);
        Assert.AreEqual(expectedOverriderControllerCount , animatorOverrideControllers.Count);
    }

#endregion
}