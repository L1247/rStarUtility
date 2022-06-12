#region

using NUnit.Framework;
using rStarUtility.Util.Helper;
using UnityEngine;

#endregion

namespace rStarUtility.Tests.Editor.Util
{
    public class VectorHelpTests
    {
    #region Test Methods

        [Test]
        public void CloseThePointV2()
        {
            var point1            = new Vector2(2 , 1);
            var point2            = new Vector2(1 , 1);
            var isCloseThePointV2 = VectorHelper.IsCloseThePoint(point1 , point2 , 1f);
            Assert.AreEqual(true , isCloseThePointV2 , "isCloseThePointV2 is not equal");
        }

    #endregion
    }
}