#region

using System;
using rStarUtility.Generic.Implement.Core;
using rStarUtility.Generic.Model;

#endregion

namespace rStarUtility.Generic.Interfaces
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