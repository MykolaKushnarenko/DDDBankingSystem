using Microsoft.EntityFrameworkCore;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Lessee;
using VenueHosting.Infrastructure.Persistence.Specification;

namespace VenueHosting.Infrastructure.Persistence.Stores;

internal sealed class LesseeStore : ILesseeStore
{
    private readonly VenueHostingDbContext _dbContext;

    public LesseeStore(VenueHostingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Lessee?> FetchBySpecification(ISpecification<Lessee> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Lessee>.GetQuery(_dbContext.Lessees, specification).FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<Lessee>> FetchAllBySpecificationAsync(ISpecification<Lessee> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Lessee>.GetQuery(_dbContext.Lessees, specification).ToListAsync(token);
    }
}