#region

using rStarUtility.Generic.Implement.Derived;
using rStarUtility.Generic.Infrastructure;
using Zenject;

#endregion

namespace rStarUtility.Generic.Installer
{
    public class GenericInstaller : Installer<GenericInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ITimeProvider>().To<TimeProvider>().AsSingle();
            Container.Bind(typeof(ITimer) , typeof(ITickable)).To<Timer>().AsSingle().IfNotBound();

            Container.BindTickableExecutionOrder<Timer>(-100);
        }

    #endregion
    }
}