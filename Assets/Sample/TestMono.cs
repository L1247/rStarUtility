#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Sample
{
    public class TestMono : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Animator animator;

    #endregion

    #region Unity events

        private void Start()
        {
            Debug.Log($"{animator.IsNull()}");
            Debug.Log($"{animator == null}");
        }

    #endregion
    }
}