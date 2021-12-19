#region

using DDDCore.Implement;
using Stat.Entity.Event;

#endregion

namespace Stat.Entity
{
    public class Stat : AggregateRoot , IStat
    {
    #region Public Variables

        public string ActorId { get; }

    #endregion

    #region Constructor

        public Stat(string id , string actorId) : base(id)
        {
            ActorId = actorId;
            var statCreated = new StatCreated(id);
            AddDomainEvent(statCreated);
        }

    #endregion
    }
}