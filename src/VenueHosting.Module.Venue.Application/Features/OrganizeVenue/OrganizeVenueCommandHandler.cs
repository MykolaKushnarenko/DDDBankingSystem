using Component.Domain.Models;
using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Domain.Repositories;
using VenueHosting.Module.Venue.Domain.Services;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

internal sealed class
    OrganizeVenueCommandHandler : IRequestHandler<OrganizeVenueCommand, Domain.Aggregates.VenueAggregate.Venue>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IAtomicScope _atomicScope;
    private readonly VenueDomainService _venueDomainService;

    public OrganizeVenueCommandHandler(
        IVenueRepository venueRepository,
        IAtomicScope atomicScope,
        VenueDomainService venueDomainService)
    {
        _venueRepository = venueRepository;
        _atomicScope = atomicScope;
        _venueDomainService = venueDomainService;
    }

    public async Task<Domain.Aggregates.VenueAggregate.Venue> Handle(OrganizeVenueCommand request,
        CancellationToken cancellationToken)
    {
        // bool placeExist = await _placeStore.CheckIfPlaceExistAsync(new FindPlaceByPlaceIdSpecification(request.PlaceId),
        //     cancellationToken);
        //
        // if (!placeExist)
        // {
        //     throw new PlaceNotFoundException();
        // }

        var venue = _venueDomainService.Create(Id<Domain.Aggregates.VenueAggregate.Venue>.CreateUnique(),
            request.HostId, request.PlaceId,
            request.EventName,
            request.Description, request.Capacity, request.Visibility, request.StartAtDateTime, request.EndAtDateTime);

        _venueRepository.Add(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return venue;
    }
}