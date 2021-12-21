#region

using Actor.Scripts.Core.DomainEvent;
using DDDCore.Event;
using DDDCore.Implement;
using Game.Stat.Scripts.Adapter;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Battle.Adapter.EventHandler
{
    public class ActorEventHandler : DomainEventHandler , IInitializable
    {
    #region Private Variables

        [Inject]
        private StatController statController;

    #endregion

    #region Constructor

        public ActorEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus) { }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            Register<ActorCreated>(OnActorCreated);
        }

    #endregion

    #region Private Methods

        private void OnActorCreated(ActorCreated created)
        {
            var actorId = created.ActorId;
            Debug.Log($"OnActorCreated: {actorId}");
            statController.CreateStat(actorId);
            statController.CreateStat(actorId);
        }

    #endregion
    }
}