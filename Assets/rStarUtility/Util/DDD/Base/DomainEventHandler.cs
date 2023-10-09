#region

using System;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public abstract class DomainEventHandler
    {
    #region Private Variables

        private readonly IDomainEventBus domainEventBus;

    #endregion

    #region Constructor

        protected DomainEventHandler(IDomainEventBus domainEventBus)
        {
            this.domainEventBus = domainEventBus;
        }

    #endregion

    #region Protected Methods

        protected void Register<T>(Action<T> callBackAction) where T : DomainEvent
        {
            domainEventBus.Register(callBackAction);
        }

    #endregion
    }
}