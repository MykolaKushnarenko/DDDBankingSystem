using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Host.ValueObjects;
using VenueHosting.Domain.Menu;
using VenueHosting.Domain.Menu.Entities;
using VenueHosting.Domain.Menu.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenusSectionsTable(builder);
        ConfigureMenuDinerIds(builder);
        ConfigureMenuReviewIds(builder);
    }

    private void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.MenuReviewIds, db =>
        {
            db.ToTable("MenuReviewIds");

            db.WithOwner().HasForeignKey("MenuId");

            db.HasKey("Id");

            db.Property(d => d.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds));
        builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinerIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.DinnerIds, db =>
        {
            db.ToTable("MenuDinerIds");

            db.WithOwner().HasForeignKey("MenuId");

            db.HasKey("Id");

            db.Property(d => d.Value)
                .HasColumnName("MenuDinerId")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds));
        builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey("Id", "MenuId");

            sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb.Property(x => x.Name)
                .HasMaxLength(100);

            sb.Property(x => x.Description)
                .HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedOnAdd()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                ib.Property(x => x.Name)
                    .HasMaxLength(100);

                ib.Property(x => x.Description)
                    .HasMaxLength(100);
            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });


        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.OwnsOne(x => x.AverageRating);

        builder
            .Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }
}