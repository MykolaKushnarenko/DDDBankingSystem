using MediatR;
using VenueHosting.Module.Payment.Domain.Bill.ValueObjects;

namespace VenueHosting.Module.Payment.Application.Features.Payment.PayForPlace;

public record PayForPlaceCommand(
    LesseeId LesseeId,
    PlaceId PlaceId,
    string CardNumber,
    int CardSecurityNumber,
    string CardHolderName,
    DateTime CardExpiration) : IRequest<Unit>;