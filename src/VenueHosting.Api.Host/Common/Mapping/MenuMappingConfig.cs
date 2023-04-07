// using Mapster;
// using VenueHosting.Application.Features.Menus.Commands.CreateMenu;
// using VenueHosting.Contracts.Manus;
// using VenueHosting.Domain.Menu;
// using VenueHosting.Domain.Menu.Entities;
// using MenuSection = VenueHosting.Domain.Menu.Entities.MenuSection;
//
// namespace VenueHosting.Api.Host.Common.Mapping;
//
// public class MenuMappingConfig : IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
//             .Map(dest => dest.HostId, src => src.HostId)
//             .Map(dest => dest, src => src.Request);
//
//         config.NewConfig<Menu, MenuResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value)
//             .Map(dest => dest.HostId, src => src.HostId.Value)
//             .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
//             .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value))
//             .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0);
//
//         config.NewConfig<MenuSection, MenuSectionResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value);
//
//         config.NewConfig<MenuItem, MenuSectionResponse>()
//             .Map(dest => dest.Id, src => src.Id.Value);
//     }
// }