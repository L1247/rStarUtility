#region

using DDDCore.Event;
using DDDCore.Implement;
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
        }

    #endregion
    }
}