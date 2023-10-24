#region

using UnityEngine;

#endregion

namespace rStarUtility.Util
{
    public static class UnityUtility
    {
    #region Public Methods

        public static Sprite CreateSprite(int width , int height)
        {
            Contract.Require(width > 0 , $"width[{width}] <=0 ");
            Contract.Require(height > 0 , $"height[{width}] <=0 ");
            var texture = new Texture2D(width , height);
            var sprite = Sprite.Create(texture , new Rect(0 , 0 , width , height) ,
                                       new Vector2(width / 2f , height / 2f));
            return sprite;
        }

    #endregion
    }
}