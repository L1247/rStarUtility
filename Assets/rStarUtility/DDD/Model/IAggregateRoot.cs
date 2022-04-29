#region

using System.Collections.Generic;
using rStarUtility.DDD.Implement.Core;

#endregion

namespace rStarUtility.DDD.Model
{
    public interface IAggregateRoot : IEntity<string>
    {
    #region Public Methods

        void              AddDomainEvent(DomainEvent domainEvent);
        void              ClearDomainEvents();
        T                 FindDomainEvent<T>() where T : DomainEvent;
        List<DomainEvent> GetDomainEvents();

    #endregion
    }
}