#region

using MessagePipe;
using rStarUtility.Generic.Implement.Core;
using rStarUtility.Generic.Infrastructure;
using Zenject;

#endregion

namespace rStarUtility.Generic.Installer
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