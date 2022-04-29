#region

using System;
using DDDCore.Implement;
using DDDCore.Model;

#endregion

namespace DDDCore.Event
{
    public interface IDomainEventBus
    {
    #region Public Methods

        void Post(DomainEvent domainEvent);

        void PostAll(IAggregateRoot aggregateRoot);
        void Register<T>(Action<T>  callBackAction) where T : DomainEvent;

    #endregion
    }
}