#region

using rStarUtility.Generic.Installer;
using rStarUtility.Generic.Interfaces;
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
            Container.Unbind<ITimeSystem>();
        }

    #endregion
    }
}