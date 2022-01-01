#region

using Actor.Adapter;
using Game.Actor.Scripts.Application.Installer;
using Game.Battle.Adapter.EventHandler;
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
            // event handler
            Container.Bind<ActorEventHandler>().To<BattleActorEventHandler>().AsSingle().NonLazy();
            Container.BindInterfacesTo<StatEventHandler>().AsSingle();

            // Aggregate installers
            ActorInstaller.Install(Container);
            StatInstaller.Install(Container);

            // Adapter layer
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();
        }

    #endregion
    }
}