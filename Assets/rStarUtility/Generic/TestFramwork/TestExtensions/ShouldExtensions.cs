#region

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;
using UnityEngine.Assertions;

#endregion

namespace rStarUtility.Generic.TestExtensions
{
    public static class ShouldExtensions
    {
    #region Public Methods

        public static void CountShouldBe<T>(this List<T> objects , int expectedCount)
        {
            objects.Count.ShouldBe(expectedCount);
        }

        public static void CountShouldBe<T>(this T[] objects , int expectedCount)
        {
            objects.Length.ShouldBe(expectedCount);
        }

        public static void CountShouldBe<T>(this IEnumerable<T> objects , int expectedCount)
        {
            objects.Count().ShouldBe(expectedCount);
        }

        public static void ShouldBe(
                this Vector2 vector2 , float expectedX , float expectedY , float precision = 0.01f)
        {
            vector2.x.Should().BeApproximately(expectedX , precision);
            vector2.y.Should().BeApproximately(expectedY , precision);
        }

        public static void ShouldBe(
                this Vector3 pos , float expectedX , float expectedY , float precision = 0.01f)
        {
            pos.x.Should().BeApproximately(expectedX , precision);
            pos.y.Should().BeApproximately(expectedY , precision);
        }

        public static void ShouldEnableBe(this Behaviour behaviour , bool expectedEnable)
        {
            behaviour.enabled.ShouldBe(expectedEnable);
        }

        public static void ShouldEnableBe(this Renderer renderer , bool expectedEnable)
        {
            renderer.enabled.ShouldBe(expectedEnable);
        }

        public static void ShouldFailure(this Output output)
        {
            output.GetExitCode().ShouldBe(ExitCode.FAILURE);
        }

        public static void ShouldID(this Output output , string id)
        {
            Assert.IsTrue(id.HasValue() , "id string is null or empty.");
            output.GetId().ShouldBe(id);
        }

        public static void ShouldSortingLayerBe(this SpriteRenderer spriteRenderer , int order)
        {
            spriteRenderer.sortingOrder.ShouldBe(order);
        }

        public static void ShouldSuccess(this Output output)
        {
            output.GetExitCode().ShouldBe(ExitCode.SUCCESS);
        }

        public static void ShouldTransformLocalPositionBe(
                this Component component , float expectedX , float expectedY , float precision = 0.01f)
        {
            var position = component.transform.localPosition;
            position.ShouldBe(expectedX , expectedY , precision);
        }

        public static void ShouldTransformPositionBe(
                this GameObject gameObject , float expectedX , float expectedY , float precision = 0.01f)
        {
            gameObject.transform.ShouldTransformPositionBe(expectedX , expectedY);
        }

        public static void ShouldTransformPositionBe(
                this Component component , float expectedX , float expectedY , float precision = 0.01f)
        {
            var position = component.transform.position;
            position.ShouldBe(expectedX , expectedY , precision);
        }

    #endregion
    }
}