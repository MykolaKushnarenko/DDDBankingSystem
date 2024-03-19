﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VenueHosting.Module.Venue.Infrastructure.Persistence;

#nullable disable

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(VenueApplicationDbContext))]
    [Migration("20240319121918_ConfiguredUserWithPlaceAndPartner")]
    partial class ConfiguredUserWithPlaceAndPartner
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Component.Domain.Persistence.Conventions.EnumConvention+EnumIdNameEntity<VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects.VenueStatus>", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VenueStatuses", "Lookup");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Organized"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Started"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Finished"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Postponed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("Component.Domain.Persistence.Conventions.EnumConvention+EnumIdNameEntity<VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects.Visibility>", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Visibilities", "Lookup");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "None"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Public"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Private"
                        });
                });

            modelBuilder.Entity("VenueHosting.Module.Venue.Domain.Aggregates.PartnerAggregate.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompanyName");

                    b.Property<Guid>("RepresentativeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RepresentativeId");

                    b.HasKey("Id");

                    b.ToTable("Partners", "Venue");
                });

            modelBuilder.Entity("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("EndAtDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndAtDateTime");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EventName");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("HostId");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PlaceId");

                    b.Property<DateTime>("StartAtDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartAtDateTime");

                    b.Property<int>("VenueStatus")
                        .HasColumnType("int")
                        .HasColumnName("VenueStatus");

                    b.Property<int>("Visibility")
                        .HasColumnType("int")
                        .HasColumnName("Visibility");

                    b.HasKey("Id");

                    b.HasIndex("VenueStatus");

                    b.HasIndex("Visibility");

                    b.ToTable("Venues", "Venue");
                });

            modelBuilder.Entity("VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Country");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.ToTable("Places", "Replica");
                });

            modelBuilder.Entity("VenueHosting.Module.Venue.Domain.Replicas.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.HasKey("Id");

                    b.ToTable("Users", "Replica");
                });

            modelBuilder.Entity("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Venue", b =>
                {
                    b.HasOne("Component.Domain.Persistence.Conventions.EnumConvention+EnumIdNameEntity<VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects.VenueStatus>", null)
                        .WithMany()
                        .HasForeignKey("VenueStatus")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Component.Domain.Persistence.Conventions.EnumConvention+EnumIdNameEntity<VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects.Visibility>", null)
                        .WithMany()
                        .HasForeignKey("Visibility")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsMany("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities.Activity", "Activities", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("Description");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Name");

                            b1.Property<Guid>("VenueId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("VenueId");

                            b1.ToTable("Activities", "Venue");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.OwnsMany("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities.Amenity", "Amenities", b1 =>
                        {
                            b1.Property<Guid>("VenueId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsAvailable")
                                .HasColumnType("bit")
                                .HasColumnName("IsAvailable");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int")
                                .HasColumnName("Quantity");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Title");

                            b1.HasKey("VenueId", "Id");

                            b1.ToTable("Amenities", "Venue");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.OwnsMany("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities.PartnerReference", "Partners", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("PartnerId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PartnerId");

                            b1.Property<Guid>("VenueId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("VenueId");

                            b1.ToTable("PartnerReferences", "Venue");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.OwnsOne("VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects.Schedule", "Schedule", b1 =>
                        {
                            b1.Property<Guid>("VenueId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("EndTime")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("EndTime");

                            b1.Property<bool>("IsBooked")
                                .HasColumnType("bit")
                                .HasColumnName("IsBooked");

                            b1.Property<DateTimeOffset>("StartTime")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("StartTime");

                            b1.HasKey("VenueId");

                            b1.ToTable("Venues", "Venue");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.Navigation("Activities");

                    b.Navigation("Amenities");

                    b.Navigation("Partners");

                    b.Navigation("Schedule")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
