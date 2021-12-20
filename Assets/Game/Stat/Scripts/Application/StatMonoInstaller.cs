#region

using DDDCore.Event;
using DDDCore.Implement;
using Game.Stat.Scripts.Adapter;
using MessagePipe;
using Zenject;

#endregion

namespace Stat.Application
{
    public class StatMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();

            Container.BindInterfacesTo<StatPresenter>().AsSingle();

            Container.Bind<StatController>().FromSubContainerResolve().ByInstaller<StatInstaller>()
                     .AsSingle();
        }

    #endregion
    }
}