#region

using Actor.Scripts;
using Actor.Scripts.Core.DomainEvent;
using DDDCore.Implement;

#endregion

namespace Actor.Entity
{
    public class Actor : AggregateRoot , IActor
    {
    #region Constructor

        public Actor(string id) : base(id)
        {
            var actorCreated = new ActorCreated(id);
            AddDomainEvent(actorCreated);
        }

    #endregion
    }
}