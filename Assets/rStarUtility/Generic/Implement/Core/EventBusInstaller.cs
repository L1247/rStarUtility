#region

using MessagePipe;
using rStarUtility.Generic.Interfaces;
using Zenject;

#endregion

namespace rStarUtility.Generic.Implement.Core
{
    public class EventBusInstaller : Installer<EventBusInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
        }

    #endregion
    }
}