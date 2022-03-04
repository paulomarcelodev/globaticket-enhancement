using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence;

public class GloboTicketDbContext : DbContext
{
    public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options)
       : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
    // public DbSet<Event> Events { get; set; }
    // public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

        //seed data, added through migrations
        var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
        var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = concertGuid,
            Name = "Concerts"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = musicalGuid,
            Name = "Musicals"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = playGuid,
            Name = "Plays"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = conferenceGuid,
            Name = "Conferences"
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
	
	