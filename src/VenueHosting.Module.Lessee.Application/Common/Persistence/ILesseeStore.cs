using VenueHosting.SharedKernel.Persistence.Storages;

namespace VenueHosting.Module.Lessee.Application.Common.Persistence;

public interface ILesseeStore : IStorageSpecification<Domain.Lessee.Lessee>
{
}