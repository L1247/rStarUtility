#region

using MessagePipe;
using rStarUtility.DDDCore.Event;
using Zenject;

#endregion

namespace rStarUtility.DDDCore.Implement.Core
{
    public class DDDInstaller : Installer<DDDInstaller>
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