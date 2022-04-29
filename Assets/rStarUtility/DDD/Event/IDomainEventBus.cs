#region

using System;
using rStarUtility.DDD.Implement.Core;
using rStarUtility.DDD.Model;

#endregion

namespace rStarUtility.DDD.Event
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