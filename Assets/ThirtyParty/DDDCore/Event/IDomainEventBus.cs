#region

using System;

#endregion

namespace DDDCore.Event
{
    public interface IDomainEventBus
    {
    #region Public Methods

        void Post(IDomainEvent     domainEvent);
        void Register<T>(Action<T> callBackAction) where T : IDomainEvent;

    #endregion
    }
}