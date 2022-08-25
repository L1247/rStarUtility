#region

using UnityEngine;

#endregion

namespace rStarUtility.Util
{
    public static class UnityUtility
    {
    #region Public Variables

        public static bool ToggleActive(this MonoBehaviour monoBehaviour)
        {
            var gameObject   = monoBehaviour.gameObject;
            var toggleActive = !gameObject.activeInHierarchy;
            gameObject.SetActive(toggleActive);
            return toggleActive;
        }

        public static bool ToggleActive(this GameObject gameObject)
        {
            var toggleActive = !gameObject.activeInHierarchy;
            gameObject.SetActive(toggleActive);
            return toggleActive;
        }

        public static Sprite CreateSprite()
        {
            var texture = new Texture2D(32 , 32);
            var sprite = Sprite.Create(texture , new Rect(0 , 0 , 32 , 32)
              , new Vector2(16 , 16));
            return sprite;
        }

    #endregion
    }
}