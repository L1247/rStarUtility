#region

using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

namespace rStarUtility.Util.Extensions
{
    public static class UniRxExtension
    {
    #region Public Variables

        public static void Binding(this Button button , Action action)
        {
            button.OnClickAsObservable().Subscribe(_ => action.Invoke())
                  .AddTo(button.gameObject);
        }

        public static void BindPointerClick(this Image image , Action<PointerEventData> action)
        {
            image.OnPointerClickAsObservable().Subscribe(action.Invoke).AddTo(image.gameObject);
        }

        public static void BindPointerDown(this Image image , Action action)
        {
            image.OnPointerDownAsObservable()
                 .Subscribe(_ => action.Invoke())
                 .AddTo(image.gameObject);
        }

        public static void BindPointerEnter(this Image image , Action<PointerEventData> action)
        {
            image.OnPointerEnterAsObservable().Subscribe(action.Invoke).AddTo(image.gameObject);
        }

        public static void BindPointerExit(this Image image , Action<PointerEventData> action)
        {
            image.OnPointerExitAsObservable().Subscribe(action.Invoke).AddTo(image.gameObject);
        }

    #endregion
    }
}