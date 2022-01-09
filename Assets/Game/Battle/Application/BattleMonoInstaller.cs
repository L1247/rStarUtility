#region

using Actor.Adapter.Interfaces;
using Game.Actor.Scripts.Application.Installer;
using Game.Battle.Application.Flows;
using Game.Battle.Application.Presenter;
using Stat.Application;
using Zenject;

#endregion

namespace Game.Battle.Application
{
    public class BattleMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            // Aggregate installers
            ActorInstaller.Install(Container);
            StatInstaller.Install(Container);

            // Application layer
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();
            Container.Bind<IActorFlow>().To<ActorFlow>().AsSingle();
        }

    #endregion
    }
}