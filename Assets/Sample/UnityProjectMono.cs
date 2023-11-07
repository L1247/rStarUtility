#region

using rStarUtility.Util;
using rStarUtility.Util.Unity;
using UnityEngine;

#endregion

namespace Sample
{
    public class UnityProjectMono : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Optional<int> fps;

        [SerializeField]
        private Optional<int> vSyncCount;

    #endregion

    #region Unity events

        private void Awake()
        {
            var unityProject = UnityProject.New();
            if (fps.Present) unityProject.WithFPS(fps.Value).ApplySettings();
            if (vSyncCount.Present) unityProject.WithVSync(vSyncCount.Value).ApplySettings();
            Debug.Log($"vSyncCount: {QualitySettings.vSyncCount}");
        }

        private void Update()
        {
            Debug.Log($"FPS: {1 / Time.deltaTime}");
        }

    #endregion
    }
}