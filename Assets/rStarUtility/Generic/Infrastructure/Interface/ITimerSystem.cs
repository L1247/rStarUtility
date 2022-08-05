#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public interface ITimerSystem
    {
    #region Public Methods

        float GetRemainingTime(string id);
        bool  IsTimerExist(string     id);

        void RegisterOnceCallBack(string id , float time , Action callback);

        void UnRegisterOnceCallBack(string id);

    #endregion
    }
}