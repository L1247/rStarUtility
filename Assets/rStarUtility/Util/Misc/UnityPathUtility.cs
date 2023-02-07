#region

using UnityEngine;

#endregion

namespace rStarUtility.Util
{
    public static class UnityPathUtility
    {
    #region Public Variables

        public const           string AssetsPathWithSlash = "Assets/";
        public static readonly string EmptyString         = string.Empty;

    #endregion

    #region Public Methods

        public static string GetPathWithoutAssetsPath(string path)
        {
            var newpath = path.Replace(AssetsPathWithSlash , EmptyString);
            return newpath;
        }

        public static string GetProjectPath()
        {
            var dataPath = Application.dataPath;
            return dataPath;
        }

    #endregion
    }
}