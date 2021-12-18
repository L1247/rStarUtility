#region

using System.Collections.Generic;
using DDDCore.Event;
using DDDCore.Model;

#endregion

namespace DDDCore.Implement
{
    public abstract class AggregateRoot : IAggregateRoot
    {
    #region Protected Variables

        protected readonly string id;

    #endregion

    #region Private Variables

        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

    #endregion

    #region Constructor

        protected AggregateRoot(string id)
        {
            this.id = id;
        }

    #endregion

    #region Public Methods

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

        public T FindDomainEvent<T>() where T : IDomainEvent
        {
            var tEvent = domainEvents.Find(domainEvent => domainEvent is T);
            return (T)tEvent;
        }

        public List<IDomainEvent> GetDomainEvents()
        {
            return domainEvents;
        }

        public string GetId()
        {
            return id;
        }

    #endregion
    }
}