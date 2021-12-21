#region

#endregion

namespace Actor.Scripts.Core.DomainEvent
{
    public class ActorCreated : DDDCore.Implement.DomainEvent
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