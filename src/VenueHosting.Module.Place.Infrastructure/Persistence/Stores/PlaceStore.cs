// using Component.Domain.Models;
// using Component.Persistence.SqlServer.AtomicScope;
// using Dapper;
// using Microsoft.AspNetCore.Authentication;
// using VenueHosting.Module.Place.Application.Common.Persistence;
// using VenueHosting.Module.Place.Domain.Place.Entities;
// using VenueHosting.Module.Place.Infrastructure.Persistence.Constants;
//
// namespace VenueHosting.Module.Place.Infrastructure.Persistence.Stores;
//
// internal sealed class PlaceStore : BaseContext, IPlaceStore
// {
//     public async Task<bool> CheckIfPlaceExistAsync(Id<Domain.Place.Place> id, IAtomicScope atomicScope)
//     {
//         bool result = await InternalFetchFirstAsync<bool>(PlaceSql.Exists, new
//         {
//             PlaceId = id.Value
//         }, atomicScope);
//
//         return result;
//     }
//
//     public async Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync(IAtomicScope atomicScope)
//     {
//         //TODO: That's critical, add with cursor paging.
//         IEnumerable<Domain.Place.Place> result =
//             await InternalFetchAsync<Domain.Place.Place>(PlaceSql.FetchAll,
//                 atomicScope);
//
//         return result.ToList();
//     }
//
//     public async Task<Domain.Place.Place> FetchAsync(Id<Domain.Place.Place> placeId, IAtomicScope atomicScope)
//     {
//         Domain.Place.Place? result = await InternalFetchAsync(async (connection, transaction) =>
//             {
//                 Dictionary<Id<Domain.Place.Place>, Domain.Place.Place> places = new();
//
//                 IEnumerable<Domain.Place.Place>? result =
//                     await connection.QueryAsync<Domain.Place.Place, Facility, Domain.Place.Place>(PlaceSql.Fetch,
//                         (place, facility) =>
//                         {
//                             if (places.TryGetValue(place.Id, out var existingPlace))
//                             {
//                                 place = existingPlace;
//                             }
//                             else
//                             {
//                                 places.Add(placeId, place);
//                             }
//
//                             place.AddFacility(facility);
//
//                             return place;
//                         },
//                         new { PlaceId = placeId.Value },
//                         splitOn: "FacilityId",
//                         transaction: transaction);
//
//                 var place = result.First();
//
//                 return place;
//
//             },
//             atomicScope);
//
//         return result;
//     }
//
//     public async Task<Id<Domain.Place.Place>> AddAsync(Domain.Place.Place place, IAtomicScope atomicScope)
//     {
//         Guid placeId = await InternalExecuteScalarAsync<Guid>(PlaceSql.Insert, new
//         {
//             PlaceId = place.Id.Value,
//             place.Status,
//             OwnerId = place.OwnerId.Value,
//             Address_Country = place.Address.Country,
//             Address_City = place.Address.City,
//             Address_Street = place.Address.Street,
//             Address_Number = place.Address.Number
//         }, atomicScope);
//
//         await AddFacilitiesAsync(placeId, place.Facilities, atomicScope);
//
//         return new Id<Domain.Place.Place>(placeId);
//     }
//
//     public async Task UpdateAsync(Domain.Place.Place place, IAtomicScope atomicScope)
//     {
//         await InternalExecuteAsync(PlaceSql.Update, new
//         {
//             PlaceId = place.Id.Value,
//             place.Status,
//             OwnerId = place.OwnerId.Value,
//             Address_Country = place.Address.Country,
//             Address_City = place.Address.City,
//             Address_Street = place.Address.Street,
//             Address_Number = place.Address.Number
//         }, atomicScope);
//     }
//
//     private async Task AddFacilitiesAsync(Guid placeId, IReadOnlyCollection<Facility> facilities, IAtomicScope atomicScope)
//     {
//         foreach (var facility in facilities)
//         {
//             await InternalExecuteAsync(PlaceSql.InsertFacility, new
//             {
//                 FacilityId = facility.Id.Value,
//                 facility.Description,
//                 facility.Name,
//                 facility.Quantity,
//                 PlaceId = placeId
//             }, atomicScope);
//         }
//     }
// }