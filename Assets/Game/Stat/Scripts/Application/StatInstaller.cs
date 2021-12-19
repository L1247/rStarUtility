#region

using DDDCore.Event;
using DDDCore.Implement;
using Game.Stat.Scripts.Adapter;
using MessagePipe;
using Stat.UseCase;
using Zenject;

#endregion

namespace Game.Stat.Scripts.Application
{
    public class StatInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.BindInterfacesTo<StatPresenter>().AsSingle();
            Container.Bind<StatController>().AsSingle();
            Container.Bind<CreateStatUseCase>().AsSingle();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.Bind<IStatRepository>().To<StatRepository>().AsSingle();
        }

    #endregion
    }
}