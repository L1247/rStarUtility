#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public interface ITimerSystem
    {
    #region Public Methods

        void RegisterOnceCallBack(string id , float time , Action callback);

        void UnRegisterOnceCallBack(string id);

    #endregion
    }
}