#region

using UnityEngine;

#endregion

namespace rStarUtility.Util.Extensions.Csharp
{
    public static class ObjectExtensions
    {
    #region Public Methods

        public static bool IsNotNull(this object obj)
        {
            return obj.IsNull().IsFalse();
        }

        /// <summary>
        ///     https://teafatesanya.blog.fc2.com/blog-entry-105.html
        ///     https://zenn.dev/rita0222/articles/be60abad73fc69
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj is Object unityObj ? unityObj == null : obj == null;
        }

    #endregion
    }
}