using System.Linq.Expressions;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.SharedKernel.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T> where T : ISupportSpecification
{
    public Expression<Func<T, bool>> Criteria { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    // Replace with cursor pagination.
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; } = false;

    protected virtual BaseSpecification<T> AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
        return this;
    }

    protected virtual BaseSpecification<T> ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;

        return this;
    }

    protected virtual BaseSpecification<T> ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;

        return this;
    }

    protected virtual BaseSpecification<T> ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;

        return this;
    }

    protected BaseSpecification<T> AddCriteria(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;

        return this;
    }
}