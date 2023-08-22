using Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            async Task PublishDomainEventsAsync()
            {
                var domainEvents = ChangeTracker
                    .Entries<Entity>()
                    .Select(entry => entry.Entity)
                        .SelectMany(entity =>
                        {
                            var domainEvents = entity.GetDomainEvents();
                            entity.ClearDomainEvents();
                            return domainEvents;
                        })
                    .ToList();

                foreach (var domainEvent in domainEvents)
                {
                    await _mediator.Publish(domainEvent);
                }
            }

            await PublishDomainEventsAsync();

            return result;
        }
    }
}
