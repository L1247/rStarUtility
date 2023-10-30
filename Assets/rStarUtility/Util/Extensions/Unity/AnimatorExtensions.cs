#region

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

        public static string GetCurrentClipName(this Animator animator)
        {
            var clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            if (clipInfos.Length == 0) return string.Empty;
            var clip = clipInfos[0].clip;
            if (clip == null) return string.Empty;
            var clipName = clip.name;
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