#region

using rStarUtility.Generic.Installer;
using Zenject;

#endregion

namespace Sample
{
    public class SampleInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            GenericInstaller.Install(Container);
        }

    #endregion
    }
}