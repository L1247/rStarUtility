#region

using Actor.Scripts.Core.DomainEvent;
using DDDCore.Implement;

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