#region

using DDDCore.Event;
using DDDCore.Implement;
using Game.Actor.Scripts.Adapter;
using MessagePipe;
using Zenject;

#endregion

namespace Actor.Application
{
    public class ActorMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();

            Container.BindInterfacesTo<ActorSamplePresenter>().AsSingle();
            Container.Bind<ActorController>().FromSubContainerResolve().ByInstaller<ActorInstaller>().AsSingle();
        }

    #endregion
    }
}