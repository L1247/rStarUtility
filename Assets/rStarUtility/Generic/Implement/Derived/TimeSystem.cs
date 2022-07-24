#region

using rStarUtility.Generic.Interfaces;
using UnityEngine;

#endregion

namespace rStarUtility.Generic.Implement.Derived
{
    internal class TimeSystem : ITimeSystem
    {
    #region Public Methods

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        public float GetTotalTime()
        {
            return Time.timeSinceLevelLoad;
        }

    #endregion
    }
}