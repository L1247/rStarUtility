#region

using System.Globalization;
using System.Threading;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Unity
{
    public class UnityProject
    {
    #region Public Variables

        /// <summary>
        ///     The default value of Application.targetFrameRate is -1. In the default case, Unity uses the platform's default target frame rate.
        ///     https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html
        /// </summary>
        public int FPS = 60;

    #endregion

    #region Private Variables

        /// <summary>
        ///     The default value of vSyncCount is 0. In the default case, Unity doesn't wait for vertical sync.
        ///     Otherwise, the value of vSyncCount must be 1 , 2 , 3 , or 4.
        ///     https://docs.unity3d.com/ScriptReference/QualitySettings-vSyncCount.html
        /// </summary>
        private int VSyncCount;

    #endregion

    #region Constructor

        private UnityProject()
        {
            // 【C#】那些因語系而產生的轉換BUG: https://teafatesanya.blog.fc2.com/blog-entry-85.html
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

    #endregion

    #region Public Methods

        public void ApplySettings()
        {
            Application.targetFrameRate = FPS;
            QualitySettings.vSyncCount  = VSyncCount;
        }

        public static UnityProject New()
        {
            return new UnityProject();
        }

        /// <summary>
        ///     The default value of Application.targetFrameRate is -1. In the default case, Unity uses the platform's default target frame rate.
        ///     https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html
        /// </summary>
        /// <param name="fps">-1 or 0 都為機器本身的更新率</param>
        /// <returns></returns>
        public UnityProject WithFPS(int fps)
        {
            FPS = fps;
            return this;
        }

        /// <summary>
        ///     The default value of vSyncCount is 0. In the default case, Unity doesn't wait for vertical sync.
        ///     Otherwise, the value of vSyncCount must be 1 , 2 , 3 , or 4.
        ///     https://docs.unity3d.com/ScriptReference/QualitySettings-vSyncCount.html
        /// </summary>
        /// <param name="vSyncCount">0為預設值不等待垂直同步，1 = fps，2 = fps / 2 以此類推</param>
        /// <returns></returns>
        public UnityProject WithVSync(int vSyncCount)
        {
            VSyncCount = vSyncCount;
            return this;
        }

    #endregion
    }
}