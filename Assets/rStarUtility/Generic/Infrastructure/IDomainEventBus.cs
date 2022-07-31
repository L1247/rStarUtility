#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public interface IDomainEventBus
    {
    #region Public Methods

        void Post(DomainEvent       domainEvent);
        void PostAll(IAggregateRoot aggregateRoot);
        void Register<T>(Action<T>  callBackAction) where T : DomainEvent;

    #endregion
    }
}