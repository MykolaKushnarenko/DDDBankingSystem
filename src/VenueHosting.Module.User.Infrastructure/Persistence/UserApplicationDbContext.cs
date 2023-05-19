using Microsoft.EntityFrameworkCore;

namespace VenueHosting.Module.User.Infrastructure.Persistence;

internal sealed class UserApplicationDbContext : DbContext
{
    public UserApplicationDbContext(DbContextOptions<UserApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.User.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("User");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}