#region

using System;
using DDDCore.Model;

#endregion

namespace DDDCore.Event
{
    public interface IDomainEventBus
    {
    #region Public Methods

        void Post(IDomainEvent domainEvent);

        void PostAll(IAggregateRoot aggregateRoot);
        void Register<T>(Action<T>  callBackAction) where T : IDomainEvent;

    #endregion
    }
}