using Microsoft.EntityFrameworkCore;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Infrastructure.Persistence.Specification;

internal static class SpecificationEvaluator<TAggregateRote> where TAggregateRote : class, IAggregateRote
{
    public static IQueryable<TAggregateRote> GetQuery(IQueryable<TAggregateRote> inputQuery,
        ISpecification<TAggregateRote> specification)
    {
        IQueryable<TAggregateRote> query = inputQuery;

        query = query.Where(specification.Criteria);

        // Includes all expression-based includes
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        // Apply ordering if expressions are set
        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        // Apply paging if enabled
        if (specification.IsPagingEnabled)
        {
            query = query
                .Skip(specification.Skip)
                .Take(specification.Take);
        }

        return query;
    }
}