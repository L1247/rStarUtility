#region

using System;
using System.Linq;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Util;
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

        private readonly Repository<Timer> timers = new Repository<Timer>();

    #endregion

    #region Public Methods

        public float GetElapsedTime(string id)
        {
            var timer = timers.FindById(id);
            return timer.ElapsedTime;
        }

        public float GetRemainingTime(string id)
        {
            var timer = timers.FindById(id);
            return timer.RemainingTime;
        }

        public bool IsTimerExist(string id)
        {
            return timers.ContainsId(id);
        }

        public Timer RegisterLoopTimer(float duration , Action callback)
        {
            if (duration <= 0)
            {
                callback?.Invoke();
                return null;
            }

            var guid  = GUID.NewGUID();
            var timer = new Timer(guid , duration , false , callback);
            timers.Save(guid , timer);
            return timer;
        }

        public void RegisterOnceTimer(string id , float duration , Action callback)
        {
            if (duration <= 0)
            {
                callback?.Invoke();
                return;
            }

            var timer = new Timer(id , duration , true , callback);
            timers.Save(id , timer);
        }

        public string RegisterOnceTimer(float duration , Action callback)
        {
            var guid = GUID.NewGUID();
            RegisterOnceTimer(guid , duration , callback);
            return guid;
        }

        public void Tick()
        {
            var deltaTime = timeProvider.GetDeltaTime();
            var ids       = timers.Keys.ToList();
            foreach (var id in ids)
            {
                var timer = timers[id];
                timer.TickTime(deltaTime);
                if (timer.End == false) continue;
                if (timer.CountOnce) UnRegisterOnceTimer(id);
                timer.Callback?.Invoke();
            }
        }

        public void UnRegisterOnceTimer(string id)
        {
            timers.DeleteById(id);
        }

    #endregion
    }
}