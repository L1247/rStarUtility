#region

using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

#endregion

namespace AutoBot.Scripts.Utilities.Extensions
{
    public static class UniRxExtension
    {
    #region Public Variables

        public static void BindClick(this Button button , Action action)
        {
            button.OnClickAsObservable()
                  .Subscribe(_ => action.Invoke())
                  .AddTo(button.gameObject);
        }

        public static void BindPointerClick(this Image image , Action action)
        {
            image.OnPointerClickAsObservable()
                 .Subscribe(_ => action.Invoke())
                 .AddTo(image.gameObject);
        }

        public static void BindPointerDown(this Image image , Action action)
        {
            image.OnPointerDownAsObservable()
                 .Subscribe(_ => action.Invoke())
                 .AddTo(image.gameObject);
        }

    #endregion
    }
}