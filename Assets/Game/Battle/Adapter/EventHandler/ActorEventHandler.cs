#region

using Actor.Scripts.Core.DomainEvent;
using DDDCore.Event;
using DDDCore.Implement;
using Stat.Adapter;
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
            var statContentViewModel = statController.GetStats(actorId);
            foreach (var statDto in statContentViewModel.Stats)
                Debug.Log($"stat: {statDto.ActorId} , {statDto.Id}");
        }

    #endregion
    }
}