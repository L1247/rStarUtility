#region

using Game.Stat.Scripts.Adapter;
using Stat.UseCase;
using Zenject;

#endregion

namespace Stat.Application
{
    public class StatInstaller : Installer
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<StatController>().AsSingle();
            Container.Bind<CreateStatUseCase>().AsSingle();
            Container.Bind<GetStatContentUseCase>().AsSingle();
            Container.Bind<IStatRepository>().To<StatRepository>().AsSingle();
        }

    #endregion
    }
}