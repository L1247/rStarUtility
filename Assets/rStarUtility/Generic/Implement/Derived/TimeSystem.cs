#region

using rStarUtility.Generic.Infrastructure;
using UnityEngine;

#endregion

namespace rStarUtility.Generic.Implement.Derived
{
    public class TimeSystem : ITimeSystem
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