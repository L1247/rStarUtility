#region

using Actor.Application;
using DDDCore.Event;
using DDDCore.Implement;
using Game.Actor.Scripts.Adapter;
using Game.Battle.Adapter.EventHandler;
using Game.Battle.Adapter.Presenter;
using Game.Stat.Scripts.Adapter;
using MessagePipe;
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
            // infrastructure
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();

            // Adapter layer
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();
            Container.Bind<ActorController>().FromSubContainerResolve().ByInstaller<ActorInstaller>().AsSingle();
            Container.Bind<StatController>().FromSubContainerResolve().ByInstaller<StatInstaller>().AsSingle();
            // event handler
            Container.BindInterfacesTo<ActorEventHandler>().AsSingle();
            Container.BindExecutionOrder<ActorEventHandler>(-20);
        }

    #endregion
    }
}