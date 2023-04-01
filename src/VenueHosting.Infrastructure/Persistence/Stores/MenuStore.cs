using System.Collections.Concurrent;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Menu;

namespace VenueHosting.Infrastructure.Persistence.Stores;

public class MenuStore : IMenuStore
{
    private readonly VenueHostingDbContext _context;

    public MenuStore(VenueHostingDbContext context)
    {
        _context = context;
    }

    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }
}