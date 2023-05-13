using VenueHosting.SharedKernel.Persistence;

namespace VenueHosting.Module.Lessee.Application.Common.Persistence;

public interface ILesseeStore : IStorageSpecification<Domain.Lessee.Lessee>
{
}