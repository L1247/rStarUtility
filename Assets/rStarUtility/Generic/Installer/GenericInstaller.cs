#region

using rStarUtility.Generic.Implement;
using rStarUtility.Generic.Interfaces;
using Zenject;

#endregion

namespace rStarUtility.Generic.Installer
{
    public class GenericInstaller : Installer<GenericInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle().IfNotBound();
        }

    #endregion
    }
}