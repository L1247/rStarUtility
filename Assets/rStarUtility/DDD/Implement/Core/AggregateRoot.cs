#region

using System.Collections.Generic;
using System.Linq;
using rStarUtility.DDD.Model;

#endregion

namespace rStarUtility.DDD.Implement.Core
{
    public abstract class AggregateRoot : IAggregateRoot
    {
    #region Private Variables

        private readonly string id;

        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();

    #endregion

    #region Constructor

        protected AggregateRoot(string id)
        {
            this.id = id;
        }

    #endregion

    #region Public Methods

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

        public T FindDomainEvent<T>() where T : DomainEvent
        {
            var tEvent = domainEvents.Find(domainEvent => domainEvent is T);
            return (T)tEvent;
        }

        public IEnumerable<T> FindDomainEvents<T>() where T : DomainEvent
        {
            var events = domainEvents.FindAll(domainEvent => domainEvent is T).Cast<T>();
            return events;
        }

        public List<DomainEvent> GetDomainEvents()
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