// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using VenueHosting.Domain.Lessee;
// using VenueHosting.Domain.Lessee.ValueObjects;
// using VenueHosting.Domain.User.ValueObjects;
//
// namespace VenueHosting.Infrastructure.Persistence.Configurations;
//
// internal sealed class LesseeConfiguration : IEntityTypeConfiguration<Lessee>
// {
//     public void Configure(EntityTypeBuilder<Lessee> builder)
//     {
//         builder.ToTable("Lessees");
//
//         builder.HasKey("Id");
//
//         builder
//             .Property(x => x.Id)
//             .ValueGeneratedNever()
//             .HasConversion(
//                 id => id.Value,
//                 value => LesseeId.Create(value));
//
//         builder
//             .Property(x => x.UserId)
//             .HasConversion(
//                 id => id.Value,
//                 value => UserId.Create(value));
//
//         builder.OwnsMany(x => x.VenueIds, navigationBuilder =>
//         {
//             navigationBuilder.WithOwner().HasForeignKey("LesseeId");
//
//             navigationBuilder.HasKey("Id");
//
//             navigationBuilder
//                 .Property(x => x.Value)
//                 .HasColumnName("Id")
//                 .ValueGeneratedNever();
//         });
//
//         builder.OwnsMany(x => x.LesseeReviewIds, navigationBuilder =>
//         {
//             navigationBuilder.WithOwner().HasForeignKey("LesseeId");
//
//             navigationBuilder.HasKey("Id");
//
//             navigationBuilder
//                 .Property(x => x.Value)
//                 .HasColumnName("Id")
//                 .ValueGeneratedNever();
//         });
//
//         builder.Metadata
//             .FindNavigation(nameof(Lessee.VenueIds))!
//             .SetPropertyAccessMode(PropertyAccessMode.Field);
//
//         builder.Metadata
//             .FindNavigation(nameof(Lessee.LesseeReviewIds))!
//             .SetPropertyAccessMode(PropertyAccessMode.Field);
//     }
// }