using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loyufei.DomainEvents
{
    public interface IAggregateRoot
    {
        public DomainEventService DomainEventService { get; }

        public Queue<IDomainEvent> Events { get; }

        public void AddEvent(IDomainEvent domainEvent);
        public void AddEvents(IEnumerable<IDomainEvent> domainEvents);

        public void ClearEvent();
    }

    public class AggregateRoot : IAggregateRoot
    {
        public DomainEventService DomainEventService { get; }

        public AggregateRoot(DomainEventService service) 
        {
            DomainEventService = service;
            Events             = new();
        }

        public Queue<IDomainEvent> Events { get; } 

        public void AddEvent (IDomainEvent domainEvent) 
        {
            Events.Enqueue(domainEvent); 
        }

        public void AddEvents(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (IDomainEvent domainEvent in domainEvents)
            {
                if (domainEvents.IsDefault()) { continue; }

                AddEvent(domainEvent);
            }
        }

        public void ClearEvent() 
        {
            Events.Clear(); 
        }
    }
}
