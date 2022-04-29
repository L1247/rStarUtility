#region

using System;
using rStarUtility.DDDCore.Implement.Core;
using rStarUtility.DDDCore.Model;

#endregion

namespace rStarUtility.DDDCore.Event
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