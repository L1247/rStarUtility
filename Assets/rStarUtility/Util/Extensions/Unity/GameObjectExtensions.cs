#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class GameObjectExtensions
    {
    #region Public Methods

        /// <summary>
        /// true = equal
        /// if(((1<<other.gameObject.layer) & includeLayers) != 0)
        // {
        // It matched one
        // }
        // if (((1 << other.gameObject.layer) & ignoreLayers) == 0)
        // {
        // It wasn't in an ignore layer
        // }
        /// </summary>
        /// <param name="layer2">LayerMask's Value</param>
        /// <returns></returns>
        public static bool CompareLayer(this GameObject gameObject , int layer2)
        {
            return ((1 << gameObject.layer) & layer2) != 0;
        }

    #endregion
    }
}