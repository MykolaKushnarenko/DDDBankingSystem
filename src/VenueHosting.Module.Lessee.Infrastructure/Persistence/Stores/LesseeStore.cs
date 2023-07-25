using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Lessee.Application.Common.Persistence;
using VenueHosting.SharedKernel.Persistence.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Lessee.Infrastructure.Persistence.Stores;

internal sealed class LesseeStore : ILesseeStore
{
    private readonly LesseeApplicationDbContext _dbContext;

    public LesseeStore(LesseeApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.Lessee.Lessee?> FetchBySpecification(ISpecification<Domain.Lessee.Lessee> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Lessee.Lessee>.GetQuery(_dbContext.Lessees, specification).FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<Domain.Lessee.Lessee>> FetchAllBySpecificationAsync(ISpecification<Domain.Lessee.Lessee> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Lessee.Lessee>.GetQuery(_dbContext.Lessees, specification).ToListAsync(token);
    }
}