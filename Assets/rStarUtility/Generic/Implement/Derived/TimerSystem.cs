#region

using System;
using System.Collections.Generic;
using rStarUtility.Generic.Infrastructure;
using Zenject;

#endregion

namespace rStarUtility.Generic.Implement.Derived
{
    public class TimerSystem : ITimerSystem , ITickable
    {
    #region Public Variables

        public int Count => timers.Count;

    #endregion

    #region Private Variables

        [Inject]
        private ITimeProvider timeProvider;

        private readonly GenericRepository<Timer> timers = new GenericRepository<Timer>();

    #endregion

    #region Public Methods

        public void RegisterOnceCallBack(string id , float time , Action callback)
        {
            if (time <= 0) callback.Invoke();
            var timer = new Timer(time , callback);
            timers.Save(id , timer);
        }


        public void Tick()
        {
            var deltaTime     = timeProvider.GetDeltaTime();
            var ids           = timers.Keys;
            var waitForRemove = new List<string>();
            foreach (var id in ids)
            {
                var complete = timers[id].TickTime(deltaTime);
                if (complete) waitForRemove.Add(id);
            }

            foreach (var id in waitForRemove) timers.DeleteById(id);
        }

        public void UnRegisterOnceCallBack(string id)
        {
            timers.DeleteById(id);
        }

    #endregion

        // private readonly List<Timer>              timers = new List<Timer>();
    }

    public class Timer
    {
    #region Private Variables

        private          float  time;
        private readonly Action callback;

    #endregion

    #region Constructor

        public Timer(float time , Action callback)
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