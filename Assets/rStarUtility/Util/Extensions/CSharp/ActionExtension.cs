#region

using System;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    public static class ActionExtension
    {
    #region Public Methods

        /// <summary>
        ///     https://zenn.dev/rita0222/articles/be60abad73fc69
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callAction"></param>
        /// <typeparam name="T"></typeparam>
        public static void Opt<T>(this T obj , Action<T> callAction)
        {
            if (obj.IsNotNull()) callAction(obj);
        }

    #endregion
    }
}