#region

using Actor.Application;
using DDDCore.Event;
using DDDCore.Implement;
using Game.Actor.Scripts.Adapter;
using Game.Battle.Adapter.Presenter;
using MessagePipe;
using Zenject;

#endregion

namespace Game.Battle.Application
{
    public class BattleMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();
            Container.Bind<ActorController>().FromSubContainerResolve().ByInstaller<ActorInstaller>().AsSingle();
        }

    #endregion
    }
}