#region

using rStarUtility.Util.Extensions.Csharp;
using rStarUtility.Util.Extensions.Unity;
using UnityEngine;
using UnityEngine.Assertions;

#endregion

namespace rStarUtility.Util.Component
{
    public class AutoDestroyWhenAnimationEnd : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private string animationName;

        [SerializeField]
        private Animator animator;

    #endregion

    #region Unity events

        private void Awake()
        {
            animator = animator.AssignWithGetComponent<Animator>(gameObject);
            Assert.IsNotNull(animator , "Invalid case , cause the animator is null or empty.");
            Assert.IsTrue(animationName.HasValue() , "animationName string is null or empty.");
        }

        private void Update()
        {
            if (animator.IsAnimationPlayEnding(animationName).IsFalse()) return;
            Destroy(gameObject);
        }

    #endregion
    }
}