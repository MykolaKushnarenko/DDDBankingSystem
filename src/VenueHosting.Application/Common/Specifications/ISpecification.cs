using System.Linq.Expressions;
using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Application.Common.Specifications;

public interface ISpecification<T> where T : IAggregateRote
{
    Expression<Func<T, bool>> Criteria { get; }

    List<Expression<Func<T, object>>> Includes { get; }

    Expression<Func<T, object>>? OrderBy { get; }

    Expression<Func<T, object>>? OrderByDescending { get; }

    int Take { get; }

    int Skip { get; }

    bool IsPagingEnabled { get; }
}