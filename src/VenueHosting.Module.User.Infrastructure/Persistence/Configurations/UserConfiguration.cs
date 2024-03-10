// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using VenueHosting.Module.User.Domain.User.ValueObjects;
//
// namespace VenueHosting.Module.User.Infrastructure.Persistence.Configurations;
//
// internal sealed class UserConfiguration : IEntityTypeConfiguration<Domain.User.User>
// {
//     public void Configure(EntityTypeBuilder<Domain.User.User> builder)
//     {
//         builder.ToTable("Users");
//
//         builder.HasKey("Id");
//
//         builder
//             .Property(x => x.Id)
//             .ValueGeneratedNever()
//             .HasConversion(
//                 id => id.Value,
//                 value => UserId.Create(value));
//
//         builder
//             .Property(x => x.LastName)
//             .HasColumnName("LastName")
//             .HasMaxLength(20);
//
//         builder
//             .Property(x => x.FirstName)
//             .HasColumnName("FirstName")
//             .HasMaxLength(20);
//
//         builder
//             .Property(x => x.Email)
//             .HasColumnName("Email")
//             .HasMaxLength(20);
//
//         builder
//             .Property(x => x.Password)
//             .HasColumnName("Password");
//
//         builder
//             .Property(x => x.UpdatedDateTime)
//             .HasColumnName("UpdatedDateTime");
//
//         builder
//             .Property(x => x.CreatedDateTime)
//             .HasColumnName("CreatedDateTime");
//     }
// }