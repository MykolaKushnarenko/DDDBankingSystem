using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Payment.Domain.Bill;

namespace VenueHosting.Module.Payment.Infrastructure.Persistence;

internal sealed class PaymentApplicationDbContext : DbContext
{
    public PaymentApplicationDbContext(DbContextOptions<PaymentApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Bill> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}