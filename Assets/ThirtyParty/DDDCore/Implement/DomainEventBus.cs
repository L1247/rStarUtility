#region

using System;
using System.Collections.Generic;
using DDDCore.Event;
using DDDCore.Model;
using MessagePipe;
using Zenject;

#endregion

namespace DDDCore.Implement
{
    public sealed class DomainEventBus : IDomainEventBus
    {
    #region Private Variables

        private readonly Dictionary<Type , List<Action<IDomainEvent>>> callBacks
            = new Dictionary<Type , List<Action<IDomainEvent>>>();

        private readonly IPublisher<IDomainEvent> publisher;

    #endregion

    #region Constructor

        [Inject]
        public DomainEventBus(ISubscriber<IDomainEvent> subscriber , IPublisher<IDomainEvent> publisher)
        {
            this.publisher = publisher;
            subscriber.Subscribe(HandleEvent);
        }

    #endregion

    #region Public Methods

        public void Post(IDomainEvent domainEvent)
        {
            publisher.Publish(domainEvent);
        }

        public void PostAll(IAggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.GetDomainEvents())
                Post(domainEvent);
            aggregateRoot.ClearDomainEvents();
        }

        public void Register<T>(Action<T> callBackAction) where T : IDomainEvent
        {
            var                        type        = typeof(T);
            var                        containsKey = callBacks.ContainsKey(type);
            List<Action<IDomainEvent>> actions;
            if (containsKey)
            {
                actions = callBacks[type];
            }
            else
            {
                actions = new List<Action<IDomainEvent>>();
                callBacks.Add(type , actions);
            }

            actions.Add(o => callBackAction((T)o));
        }

    #endregion

    #region Private Methods

        private void HandleEvent(IDomainEvent domainEvent)
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