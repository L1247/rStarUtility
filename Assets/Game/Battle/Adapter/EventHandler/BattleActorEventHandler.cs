#region

using Actor.Scripts.Core.DomainEvent;
using DDDCore.Event;
using Game.Actor.Scripts.Adapter.Gateway.Eventbus;
using Stat.Adapter;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Battle.Adapter.EventHandler
{
    public class BattleActorEventHandler : ActorEventHandler
    {
    #region Private Variables

        [Inject]
        private StatController statController;

    #endregion

    #region Constructor

        protected BattleActorEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus) { }

    #endregion

    #region Protected Methods

        protected override void OnActorCreated(ActorCreated created)
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