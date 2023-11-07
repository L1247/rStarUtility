#region

using rStarUtility.Util.Unity;
using UnityEngine;

#endregion

namespace Sample
{
    public class UnityProjectMono : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private int fps;

        [SerializeField]
        private int vSyncCount;

    #endregion

    #region Unity events

        private void Awake()
        {
            UnityProject.New().WithFPS(fps).WithVSync(vSyncCount).ApplySettings();
            Debug.Log($"vSyncCount: {QualitySettings.vSyncCount}");
        }

        private void Update()
        {
            Debug.Log($"FPS: {1 / Time.deltaTime}");
        }

    #endregion
    }
}