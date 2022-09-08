#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Timer
    {
    #region Public Variables

        public Action Callback  { get; }
        public bool   CountOnce { get; }
        public bool   End       { get; private set; }

        public float Duration      { get; }
        public float ElapsedTime   { get; private set; }
        public float RemainingTime { get; private set; }

    #endregion

    #region Constructor

        public Timer(float duration , bool countOnce , Action callback)
        {
            CountOnce     = countOnce;
            RemainingTime = duration;
            Callback      = callback;
            Duration      = duration;
        }

    #endregion

    #region Public Methods

        public void TickTime(float deltaTime)
        {
            RemainingTime -= deltaTime;
            ElapsedTime   += deltaTime;
            if (RemainingTime <= 0)
            {
                End           = true;
                RemainingTime = Duration;
                ElapsedTime   = 0;
            }
            else if (End)
            {
                End = false;
            }
        }

    #endregion
    }
}