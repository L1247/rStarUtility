#region

using System.Collections.Generic;

#endregion

namespace rStarUtility.Generic.Infrastructure
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