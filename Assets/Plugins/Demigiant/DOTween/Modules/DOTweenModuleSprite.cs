﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2018/07/13

#if true && (UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_5 || UNITY_2017_1_OR_NEWER) // MODULE_MARKER

#region

using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#endregion

#pragma warning disable 1591
namespace DG.Tweening
{
    public static class DOTweenModuleSprite
    {
    #region Shortcuts

    #region SpriteRenderer

        /// <summary>
        ///     Tweens a SpriteRenderer's color to the given value.
        ///     Also stores the spriteRenderer as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="duration">The duration of the tween</param>
        public static TweenerCore<Color , Color , ColorOptions> DOColor(this SpriteRenderer target , Color endValue , float duration)
        {
            var t = DOTween.To(() => target.color , x => target.color = x , endValue , duration);
            t.SetTarget(target);
            return t;
        }

        /// <summary>
        ///     Tweens a Material's alpha color to the given value.
        ///     Also stores the spriteRenderer as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="duration">The duration of the tween</param>
        public static TweenerCore<Color , Color , ColorOptions> DOFade(this SpriteRenderer target , float endValue , float duration)
        {
            var t = DOTween.ToAlpha(() => target.color , x => target.color = x , endValue , duration);
            t.SetTarget(target);
            return t;
        }

        /// <summary>
        ///     Tweens a SpriteRenderer's color using the given gradient
        ///     (NOTE 1: only uses the colors of the gradient, not the alphas - NOTE 2: creates a Sequence, not a Tweener).
        ///     Also stores the image as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="gradient">The gradient to use</param>
        /// <param name="duration">The duration of the tween</param>
        public static Sequence DOGradientColor(this SpriteRenderer target , Gradient gradient , float duration)
        {
            var s      = DOTween.Sequence();
            var colors = gradient.colorKeys;
            var len    = colors.Length;
            for (var i = 0 ; i < len ; ++i)
            {
                var c = colors[i];
                if (i == 0 && c.time <= 0)
                {
                    target.color = c.color;
                    continue;
                }

                var colorDuration = i == len - 1
                                        ? duration - s.Duration(false) // Verifies that total duration is correct
                                        : duration * (i == 0 ? c.time : c.time - colors[i - 1].time);
                s.Append(target.DOColor(c.color , colorDuration).SetEase(Ease.Linear));
            }

            s.SetTarget(target);
            return s;
        }

    #endregion

    #region Blendables

    #region SpriteRenderer

        /// <summary>
        ///     Tweens a SpriteRenderer's color to the given value,
        ///     in a way that allows other DOBlendableColor tweens to work together on the same target,
        ///     instead than fight each other as multiple DOColor would do.
        ///     Also stores the SpriteRenderer as the tween's target so it can be used for filtered operations
        /// </summary>
        /// <param name="endValue">The value to tween to</param>
        /// <param name="duration">The duration of the tween</param>
        public static Tweener DOBlendableColor(this SpriteRenderer target , Color endValue , float duration)
        {
            endValue = endValue - target.color;
            var to = new Color(0 , 0 , 0 , 0);
            return DOTween.To(() => to , x =>
                          {
                              var diff = x - to;
                              to           =  x;
                              target.color += diff;
                          } , endValue , duration)
                          .Blendable().SetTarget(target);
        }

    #endregion

    #endregion

    #endregion
    }
}
#endif