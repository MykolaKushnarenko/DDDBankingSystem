// using VenueHosting.Module.Venue.Application;
//
// namespace VenueHosting.Module.Payment.Infrastructure.Persistence.AtomicScope;
//
// internal sealed class AtomicScope : IAtomicScope
// {
//     private readonly PaymentApplicationDbContext _dbContext;
//
//     public AtomicScope(PaymentApplicationDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//
//     public async Task CommitAsync(CancellationToken token)
//     {
//         //Dispatch all domain events before commiting a transaction.
//         //await _publisher.DispatchEventsAsync(_dbContext);
//
//         await _dbContext.SaveChangesAsync(token);
//     }
// }