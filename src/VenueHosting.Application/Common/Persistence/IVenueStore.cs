using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Common.Persistence;

public interface IVenueStore
{
    Task<Venue?> FetchVenueByIdAsync(VenueId venueId);

    Task<IReadOnlyList<Venue>> FetchAllVenuesByAttendeeId(AttendeeId attendeeId);

    Task AddAsync(Venue venue);
}