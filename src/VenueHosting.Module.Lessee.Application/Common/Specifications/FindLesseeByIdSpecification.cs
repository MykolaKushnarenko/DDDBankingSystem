using VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Lessee.Application.Common.Specifications;

public class FindLesseeByIdSpecification : BaseSpecification<Domain.Lessee.Lessee>
{
    public FindLesseeByIdSpecification(LesseeId lesseeId)
    {
        AddCriteria(x => x.Id == lesseeId);
    }
}