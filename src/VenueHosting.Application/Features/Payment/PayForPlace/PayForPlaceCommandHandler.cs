using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Application.Common.Specifications;

namespace VenueHosting.Application.Features.Payment.PayForPlace;

public class PayForPlaceCommandHandler : IRequestHandler<PayForPlaceCommand, Unit>
{
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScope _atomicScope;

    public PayForPlaceCommandHandler(IPlaceStore placeStore, IAtomicScope atomicScope)
    {
        _placeStore = placeStore;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(PayForPlaceCommand request, CancellationToken cancellationToken)
    {
        //Introduce payment process.

        Domain.Place.Place? place = await _placeStore.FetchBySpecification(new FindPlaceByPlaceIdSpecification(request.PlaceId), cancellationToken);

        place.BookPlace();

        _placeStore.UpdateAsync(place);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}