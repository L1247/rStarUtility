#region

using Actor.Scripts.Core.DomainEvent;
using DDDCore.Event;
using DDDCore.Implement;
using UnityEngine;

#endregion

namespace Actor.Adapter
{
    public class ActorEventHandler : DomainEventHandler
    {
    #region Constructor

        protected ActorEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus)
        {
            Register<ActorCreated>(OnActorCreated);
        }

    #endregion

    #region Protected Methods

        protected virtual void OnActorCreated(ActorCreated created)
        {
            Debug.Log($"{created.ActorId}");
        }

    #endregion
    }
}