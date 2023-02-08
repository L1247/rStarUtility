#region

using System.Linq;
using UnityEditor.PackageManager;
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

        public static string GetDataPathWithoutAssets()
        {
            return Application.dataPath.Replace("/Assets" , string.Empty);
        }

        public static string GetPackageAssetPath(string packageDisplayName)
        {
            var packageInfo = GetPackageInfo(packageDisplayName);
            return packageInfo.assetPath;
        }

        public static PackageInfo GetPackageInfo(string packageDisplayName)
        {
            var packageInfo = PackageInfo.GetAllRegisteredPackages().First(info => info.displayName == packageDisplayName);
            return packageInfo;
        }

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
            return GetPackageInfo(packageDisplayName).resolvedPath.ReplaceStringForForwardSlash();
        }

    #endregion
    }
}