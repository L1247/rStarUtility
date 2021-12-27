#region

using Game.Actor.Scripts.Application.Installer;
using Game.Battle.Adapter.EventHandler;
using Game.Battle.Adapter.Presenter;
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

            // Adapter layer
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();

            // event handler
            Container.BindInterfacesTo<ActorEventHandler>().AsSingle();
            Container.BindInterfacesTo<StatEventHandler>().AsSingle();
        }

    #endregion
    }
}