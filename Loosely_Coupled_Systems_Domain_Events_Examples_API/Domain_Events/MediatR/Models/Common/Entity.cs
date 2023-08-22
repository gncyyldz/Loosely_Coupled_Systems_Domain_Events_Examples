namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models.Common
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents;
        public Entity()
            => _domainEvents = new();

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
            => _domainEvents.ToList();

        public void ClearDomainEvents()
            => _domainEvents.Clear();

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);
    }
}
