#region

using Actor.Adapter.Interfaces;
using DDDCore.Event;
using DDDCore.Implement;
using Game.Actor.Scripts.Entity.Actor.ExposedActor.Event;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Adapter.Gateway.Eventbus
{
    public class ActorEventHandler : DomainEventHandler
    {
    #region Private Variables

        [Inject]
        private IActorFlow actorFlow;

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
            actorFlow.WhenActorCreated();
        }

    #endregion
    }
}