#region

using rStarUtility.Util.Zenject;
using UnityEngine;

#endregion

namespace Sample
{
    [CreateAssetMenu(fileName = "TestSoInstaller" , menuName = "TestSoInstaller" , order = 0)]
    public class TestSoInstaller : SOInstaller<TestSoInstaller>
    {
    #region Protected Variables

        protected static string resourcePath => "TestSoInstaller";

    #endregion
    }
}