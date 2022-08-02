#region

using System;
using System.Collections.Generic;
using rStarUtility.Generic.Infrastructure;
using UnityEngine;
using Zenject;

#endregion

namespace rStarUtility.Generic.Implement.Derived
{
    public class Timer : ITimer , ITickable
    {
    #region Public Variables

        public int Count => timerStates.Count;

    #endregion

    #region Private Variables

        [Inject]
        private ITimeProvider timeProvider;

        private readonly List<TimerState> timerStates = new List<TimerState>();

    #endregion

    #region Public Methods

        public void RegisterOnceCallBack(float time , Action callback)
        {
            if (time <= 0) callback.Invoke();
            var timerState = new TimerState(time , callback);
            timerStates.Add(timerState);
        }

        public void Tick()
        {
            var deltaTime = timeProvider.GetDeltaTime();
            Debug.Log($"{deltaTime}");
            for (var i = timerStates.Count - 1 ; i >= 0 ; i--)
            {
                var complete = timerStates[i].TickTime(deltaTime);
                if (complete) timerStates.RemoveAt(i);
            }
        }

    #endregion
    }

    public class TimerState
    {
    #region Private Variables

        private          float  time;
        private readonly Action callback;

    #endregion

    #region Constructor

        public TimerState(float time , Action callback)
        {
            this.time     = time;
            this.callback = callback;
        }

    #endregion

    #region Public Methods

        public bool TickTime(float deltaTime)
        {
            time -= deltaTime;
            var complete = time <= 0;
            if (complete) callback.Invoke();
            return complete;
        }

    #endregion
    }
}