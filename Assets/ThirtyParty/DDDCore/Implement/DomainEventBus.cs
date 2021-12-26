#region

using System;
using System.Collections.Generic;
using DDDCore.Event;
using DDDCore.Model;
using MessagePipe;

#endregion

namespace DDDCore.Implement
{
    public sealed class DomainEventBus : IDomainEventBus
    {
    #region Private Variables

        private readonly Dictionary<Type , List<Action<DomainEvent>>> callBacks
            = new Dictionary<Type , List<Action<DomainEvent>>>();

        private readonly IPublisher<DomainEvent> publisher;

    #endregion

    #region Constructor

        public DomainEventBus(ISubscriber<DomainEvent> subscriber , IPublisher<DomainEvent> publisher)
        {
            this.publisher = publisher;
            subscriber.Subscribe(HandleEvent);
        }

    #endregion

    #region Public Methods

        public void Post(DomainEvent domainEvent)
        {
            publisher.Publish(domainEvent);
        }

        public void PostAll(IAggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.GetDomainEvents())
                Post(domainEvent);
            aggregateRoot.ClearDomainEvents();
        }

        public void Register<T>(Action<T> callBackAction) where T : DomainEvent
        {
            var                       type        = typeof(T);
            var                       containsKey = callBacks.ContainsKey(type);
            List<Action<DomainEvent>> actions;
            if (containsKey)
            {
                actions = callBacks[type];
            }
            else
            {
                actions = new List<Action<DomainEvent>>();
                callBacks.Add(type , actions);
            }

            actions.Add(o => callBackAction((T)o));
        }

    #endregion

    #region Private Methods

        private void HandleEvent(DomainEvent domainEvent)
        {
            var type        = domainEvent.GetType();
            var containsKey = callBacks.ContainsKey(type);
            if (containsKey)
            {
                var actions = callBacks[type];
                foreach (var action in actions)
                    action.Invoke(domainEvent);
            }
        }

    #endregion
    }
}