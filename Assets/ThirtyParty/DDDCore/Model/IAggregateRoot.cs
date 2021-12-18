#region

#endregion

#region

using System.Collections.Generic;
using DDDCore.Event;

#endregion

namespace DDDCore.Model
{
    public interface IAggregateRoot : IEntity<string>
    {
    #region Public Methods

        void               AddDomainEvent(IDomainEvent domainEvent);
        void               ClearDomainEvents();
        T                  FindDomainEvent<T>() where T : IDomainEvent;
        List<IDomainEvent> GetDomainEvents();

    #endregion
    }
}