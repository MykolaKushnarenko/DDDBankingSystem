using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;

internal sealed class VenueReservationMustNotAlreadyExistBusinessRule : IBusinessRule
{
    private readonly IList<Reservation> _allReservations;

    private readonly Reservation _addingReservation;

    public VenueReservationMustNotAlreadyExistBusinessRule(IList<Reservation> allReservations,
        Reservation addingReservation)
    {
        _allReservations = allReservations;
        _addingReservation = addingReservation;
    }

    public void CheckIfSatisfied()
    {
        if (_allReservations.Contains(_addingReservation))
        {
            throw new VenueReservationDuplicateFoundException();
        }
    }
}