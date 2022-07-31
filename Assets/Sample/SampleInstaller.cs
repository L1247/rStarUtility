#region

using rStarUtility.Generic.Infrastructure;
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
            Container.Unbind<ITimeSystem>();
        }

    #endregion
    }
}