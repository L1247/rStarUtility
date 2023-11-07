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

        public int FPS = 60;

    #endregion

    #region Private Variables

        private int VSyncCount = 1;

    #endregion

    #region Constructor

        private UnityProject()
        {
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

        public UnityProject WithFPS(int fps)
        {
            FPS = fps;
            return this;
        }

        public UnityProject WithVSync(int vSyncCount)
        {
            VSyncCount = vSyncCount;
            return this;
        }

    #endregion
    }
}