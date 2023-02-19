#region

using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif

#endregion

namespace rStarUtility.Util
{
    public static class UnityPathUtility
    {
    #region Public Variables

        public const string AssetsPathWithSlash = "Assets/";

    #endregion

    #region Private Variables

        private static readonly string EmptyString = string.Empty;

    #endregion

    #region Public Methods

        public static string GetDataPathWithoutAssets()
        {
            return Application.dataPath.Replace("/Assets" , EmptyString);
        }

        public static string GetPackageAssetPath(string packageDisplayName)
        {
            var packageInfoAssetPath = EmptyString;
        #if UNITY_EDITOR
            var packageInfo = GetPackageInfo(packageDisplayName);
            packageInfoAssetPath = packageInfo.assetPath;
        #endif
            return packageInfoAssetPath;
        }

    #if UNITY_EDITOR
        public static PackageInfo GetPackageInfo(string packageDisplayName)
        {
            var packageInfo = PackageInfo.GetAllRegisteredPackages()
                                         .First(info => info.displayName == packageDisplayName);
            return packageInfo;
        }
    #endif

        public static string GetPackageName(string packageDisplayName)
        {
            return GetPackageAssetPath(packageDisplayName).Replace("Packages/" , EmptyString);
        }

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

        public static string ResolvingAbsolutePath(string packageDisplayName)
        {
            var replaceStringForForwardSlash = EmptyString;
        #if UNITY_EDITOR
            replaceStringForForwardSlash = GetPackageInfo(packageDisplayName).resolvedPath.ReplaceStringForForwardSlash();
        #endif
            return replaceStringForForwardSlash;
        }

    #endregion
    }
}