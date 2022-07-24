#region

using System.Collections.Generic;
using rStarUtility.Generic.Implement.Core;

#endregion

namespace rStarUtility.Generic.Model
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