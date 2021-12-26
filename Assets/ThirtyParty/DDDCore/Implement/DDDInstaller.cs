#region

using DDDCore.Event;
using MessagePipe;
using Zenject;

#endregion

namespace DDDCore.Implement
{
    public class DDDInstaller : Installer<DDDInstaller>
    {
    #region Overrides of InstallerBase

        public override void InstallBindings()
        {
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<DomainEvent>(option);
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
        }

    #endregion
    }
}