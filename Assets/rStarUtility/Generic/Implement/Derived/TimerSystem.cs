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

        private readonly GenericRepository<Timer> timers = new GenericRepository<Timer>();

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

        public void RegisterOnceCallBack(string id , float time , Action callback)
        {
            if (time <= 0)
            {
                callback.Invoke();
                return;
            }

            var timer      = new Timer(time , true , callback);
            var containsId = timers.ContainsId(id);
            timers.Save(id , timer);
        }

        public string RegisterOnceCallBack(float time , Action callback)
        {
            var guid = GUID.NewGUID();
            RegisterOnceCallBack(guid , time , callback);
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
                if (timer.CountOnce) UnRegisterOnceCallBack(id);
                timer.Callback.Invoke();
            }
        }

        public void UnRegisterOnceCallBack(string id)
        {
            timers.DeleteById(id);
        }

    #endregion
    }

    public class Timer
    {
    #region Public Variables

        public Action Callback      { get; }
        public bool   CountOnce     { get; }
        public bool   End           { get; private set; }
        public float  ElapsedTime   { get; private set; }
        public float  RemainingTime { get; private set; }

    #endregion

    #region Constructor

        public Timer(float duration , bool countOnce , Action callback)
        {
            CountOnce     = countOnce;
            RemainingTime = duration;
            Callback      = callback;
        }

    #endregion

    #region Public Methods

        public void TickTime(float deltaTime)
        {
            RemainingTime -= deltaTime;
            ElapsedTime   += deltaTime;
            if (RemainingTime <= 0) End = true;
        }

    #endregion
    }
}