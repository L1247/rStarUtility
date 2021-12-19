#region

using DDDCore.Event;

#endregion

namespace Actor.Scripts.Core.DomainEvent
{
    public class ActorCreated : IDomainEvent
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