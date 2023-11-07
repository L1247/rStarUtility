#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Unity
{
    public static class AnimatorExtensions
    {
    #region Public Methods

        // todo: 演算法不太對，待調整與寫單元測試
        public static int GetAnimationFrameOfCurrentClip(this Animator animator)
        {
            var clipInfo                 = animator.GetCurrentAnimatorClipInfo(0)[0];
            var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            var clip                     = clipInfo.clip;
            var clipFrameRate            = clip.frameRate;
            var normalizedTime           = currentAnimatorStateInfo.normalizedTime;
            var frameTime                = clip.length * (normalizedTime % 1);
            var frame                    = frameTime * clipFrameRate;
            return (int)frame + 1;
        }

        /// <summary>
        ///     if invalid case return string.Empty.
        /// </summary>
        /// <param name="animator"></param>
        /// <returns>if invalid case return string.Empty.</returns>
        public static string GetCurrentClipName(this Animator animator)
        {
            if (animator.IsRuntimeAnimatorNull()) return string.Empty;
            var clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            if (clipInfos.Length == 0) return string.Empty;
            var clip = clipInfos[0].clip;
            if (clip == null) return string.Empty;
            var clipName = clip.name;
            return clipName;
        }

        public static float GetNormalizedTime(this Animator animator)
        {
            if (animator.IsRuntimeAnimatorNull()) return 0f;
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
            if (animator.IsRuntimeAnimatorNull()) return false;
            var animationPlayEnding = animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
            return animationPlayEnding;
        }

        public static bool IsPlayingAnimation(this Animator animator , string animationName)
        {
            var isPlayingAnimation = GetCurrentClipName(animator) == animationName;
            return isPlayingAnimation;
        }

        public static bool IsRuntimeAnimatorNull(this Animator animator)
        {
            return animator.runtimeAnimatorController.IsNull();
        }

    #endregion
    }
}