#region

using Actor.Adapter.Interfaces;
using Actor.Scripts.Core.DomainEvent;
using DDDCore.Event;
using DDDCore.Implement;
using Zenject;

#endregion

namespace Actor.Adapter
{
    public class ActorEventHandler : DomainEventHandler
    {
    #region Private Variables

        [Inject]
        private IActorPresenter actorPresenter;

    #endregion

    #region Constructor

        protected ActorEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus)
        {
            Register<ActorCreated>(OnActorCreated);
        }

    #endregion

    #region Protected Methods

        protected virtual void OnActorCreated(ActorCreated created)
        {
            actorPresenter.CreateActor();
        }

    #endregion
    }
}