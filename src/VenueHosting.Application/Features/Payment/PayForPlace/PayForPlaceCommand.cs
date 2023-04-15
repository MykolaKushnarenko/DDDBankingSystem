using MediatR;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Features.Payment.PayForPlace;

public record PayForPlaceCommand(
    LesseeId LesseeId,
    PlaceId PlaceId,
    string CardNumber,
    int CardSecurityNumber,
    string CardHolderName,
    DateTime CardExpiration) : IRequest<Unit>;