using VenueHosting.Domain.Menu;

namespace VenueHosting.Application.Common.Persistence;

public interface IMenuStore
{
    void Add(Menu menu);
}