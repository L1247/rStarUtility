#region

#endregion

#region

using DDDCore.Implement;

#endregion

namespace Game.Actor.Scripts.Entity.Actor.ExposedActor.Event
{
    public class ActorCreated : DomainEvent
    {
    #region Public Variables

        public string ActorId { get; }

    #endregion

    #region Constructor

        public ActorCreated(string actorId)
        {
            ActorId = actorId;
        }

    #endregion
    }
}