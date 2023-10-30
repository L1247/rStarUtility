#region

using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util.Extensions.Unity;
using UnityEngine;

#endregion

public class UnityExtensionTests : DIUnitTestFixture
{
#region Test Methods

    [Test]
    public void _01_TryGetComponentInParent()
    {
        var gameObject = new GameObject();
        var collider2D = gameObject.AddComponent<BoxCollider2D>();
        var found      = collider2D.TryGetComponentInParent<BoxCollider2D>(out var foundCollider);
        found.ShouldBe(true);
        foundCollider.ShouldBe(collider2D);
        found = gameObject.TryGetComponentInParent(out foundCollider);
        found.ShouldBe(true);
        foundCollider.ShouldBe(collider2D);
    }

    [Test]
    public void _02_TryGetComponentInChildren()
    {
        var gameObject = new GameObject();
        var collider2D = gameObject.AddComponent<BoxCollider2D>();
        var found      = collider2D.TryGetComponentInChildren<BoxCollider2D>(out var foundCollider);
        found.ShouldBe(true);
        foundCollider.ShouldBe(collider2D);
        found = gameObject.TryGetComponentInChildren(out foundCollider);
        found.ShouldBe(true);
        foundCollider.ShouldBe(collider2D);
    }

#endregion
}