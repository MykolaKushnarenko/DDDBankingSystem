using VenueHosting.Domain.Lessee.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public class FindLesseeByIdSpecification : BaseSpecification<Domain.Lessee.Lessee>
{
    public FindLesseeByIdSpecification(LesseeId lesseeId)
    {
        AddCriteria(x => x.Id == lesseeId);
    }
}