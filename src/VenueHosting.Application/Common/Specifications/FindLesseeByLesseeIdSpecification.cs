using VenueHosting.Domain.Lessee.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public sealed class LesseeByLesseeIdSpecification : BaseSpecification<Domain.Place.Place>
{
    public LesseeByLesseeIdSpecification(LesseeId id)
    {
        AddCriteria(x => x.Id == id);
    }
}