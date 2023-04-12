using Microsoft.EntityFrameworkCore;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Attendee;
using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Stores;

internal sealed class VenueStore : IVenueStore
{
    private readonly VenueHostingDbContext _dbContext;

    public VenueStore(VenueHostingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Venue?> FetchVenueByIdAsync(VenueId venueId)
    {
        return _dbContext.Venues.Where(x => x.Id == venueId).SingleOrDefaultAsync();
    }

    public async Task<IReadOnlyList<Venue>> FetchAllVenuesByAttendeeId(AttendeeId attendeeId)
    {
        Attendee attendee = await _dbContext.Attendees.Where(x => x.Id == attendeeId).SingleAsync();
        return await _dbContext.Venues.Where(x => attendee.VenueIds.Contains(x.Id)).ToListAsync();
    }

    public async Task AddAsync(Venue venue)
    {
        await _dbContext.Venues.AddAsync(venue);
    }
}