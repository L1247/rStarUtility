#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public interface ITimer
    {
    #region Public Methods

        void RegisterOnceCallBack(float time , Action callback);

    #endregion
    }
}