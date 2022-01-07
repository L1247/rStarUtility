#region

using Actor.ExposedActor.Interfaces;
using DDDCore.Implement;
using Game.Actor.Scripts.Entity.Actor.ExposedActor.Event;

#endregion

namespace Actor.Entity
{
    public class Actor : AggregateRoot , IActorReadModel , IActorCommand
    {
    #region Public Variables

        public string DataId { get; }

    #endregion

    #region Constructor

        public Actor(string id , string dataId) : base(id)
        {
            DataId = dataId;
            var actorCreated = new ActorCreated(id);
            AddDomainEvent(actorCreated);
        }

    #endregion
    }
}