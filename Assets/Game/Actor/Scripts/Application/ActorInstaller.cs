#region

using Actor.Scripts.Core.UseCase;
using DDDCore.Event;
using DDDCore.Implement;
using Game.Actor.Scripts.Adapter;
using MessagePipe;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Framework
{
    public class ActorInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<IDomainEvent>(option);
            Container.BindInterfacesTo<ActorSamplePresenter>().AsSingle();
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
        }

    #endregion
    }
}