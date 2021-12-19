#region

using DDDCore.Implement;
using Stat.Entity.Event;

#endregion

namespace Stat.Entity
{
    public class Stat : AggregateRoot , IStat
    {
    #region Constructor

        public Stat(string id) : base(id)
        {
            var statCreated = new StatCreated(id);
            AddDomainEvent(statCreated);
        }

    #endregion
    }
}