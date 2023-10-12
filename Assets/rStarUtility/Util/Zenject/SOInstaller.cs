#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine.Assertions;
using Zenject;

#endregion

namespace rStarUtility.Util.Zenject
{
    public abstract class SOInstaller<T> : ScriptableObjectInstaller<T> where T : ScriptableObjectInstaller<T>
    {
    #region Protected Variables

        protected static string resourcePath => "";

    #endregion

    #region Public Methods

        public static void InstallThis(DiContainer container)
        {
            Assert.IsTrue(resourcePath.HasValue() , "resourcePath string is null or empty.");
            InstallFromResource(resourcePath , container);
        }

    #endregion
    }
}