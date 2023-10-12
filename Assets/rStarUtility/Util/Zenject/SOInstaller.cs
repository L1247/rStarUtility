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

        /// <summary>
        ///     override the resourcePath for this SOInstaller is required.
        ///     Here is example
        ///     protected new static string resourcePath => "XXXSettings";
        /// </summary>
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