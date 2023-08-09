#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class AnimatorExtensions
    {
    #region Public Methods

        public static string GetCurrentClipName(this Animator animator)
        {
            var clipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            return clipName;
        }

        public static float GetNormalizedTime(this Animator animator)
        {
            var normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return normalizedTime;
        }

        public static bool IsAnimationPlayEnding(this Animator animator , string animationName)
        {
            var isPlayingAnimation    = animator.IsPlayingAnimation(animationName);
            var isPlayEnding          = animator.IsPlayEnding();
            var isAnimationPlayEnding = isPlayingAnimation && isPlayEnding;
            return isAnimationPlayEnding;
        }

        public static bool IsPlayEnding(this Animator animator)
        {
            var animationPlayEnding = animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
            return animationPlayEnding;
        }

        public static bool IsPlayingAnimation(this Animator animator , string animationName)
        {
            var isPlayingAnimation = GetCurrentClipName(animator) == animationName;
            return isPlayingAnimation;
        }

    #endregion
    }
}