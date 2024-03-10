using Component.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Component.Persistence.SqlServer.Specifications;

public static class SpecificationEvaluator<TSupportSpecification> where TSupportSpecification : class, IAggregateRote
{
    public static IQueryable<TSupportSpecification> GetQuery(IQueryable<TSupportSpecification> inputQuery,
        ISpecification<TSupportSpecification> specification)
    {
        IQueryable<TSupportSpecification> query = inputQuery;

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