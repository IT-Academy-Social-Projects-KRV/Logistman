﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220623070816_RemoveExpirationDateFromOffers")]
    partial class RemoveExpirationDateFromOffers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.CarCategoryEntity.CarCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarCategory");
                });

            modelBuilder.Entity("Core.Entities.CarEntity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<float>("LoadCapacity")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TechnicalPassport")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Vin")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Core.Entities.GoodCategoryEntity.GoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("GoodCategories");
                });

            modelBuilder.Entity("Core.Entities.InviteEntity.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnswered")
                        .HasColumnType("bit");

                    b.Property<int?>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OfferId")
                        .IsUnique()
                        .HasFilter("[OfferId] IS NOT NULL");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Core.Entities.OfferEntity.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CreatorRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoodCategoryId")
                        .HasColumnType("int");

                    b.Property<float>("GoodsWeight")
                        .HasColumnType("real");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("OfferCreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OfferPointId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedTripId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatorRoleId");

                    b.HasIndex("GoodCategoryId");

                    b.HasIndex("OfferCreatorId");

                    b.HasIndex("OfferPointId");

                    b.HasIndex("RelatedTripId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Core.Entities.PointEntity.PointData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsStopover")
                        .HasColumnType("bit");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Settlement")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Core.Entities.RatingEntity.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstimatorUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("RatedUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("RatingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstimatorUserId");

                    b.HasIndex("RatedUserId");

                    b.HasIndex("TripId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Core.Entities.RefreshTokenEntity.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Entities.ReportEntity.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportedUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReporterUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("ReportingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportedUserId");

                    b.HasIndex("ReporterUserId");

                    b.HasIndex("TripId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Core.Entities.RoleEntity.OfferRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfferRoles");
                });

            modelBuilder.Entity("Core.Entities.TripEntity.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Distance")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ExpirationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnded")
                        .HasColumnType("bit");

                    b.Property<float>("LoadCapacity")
                        .HasColumnType("real");

                    b.Property<int>("MaxRouteDeviationKm")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TransportationCarId")
                        .HasColumnType("int");

                    b.Property<string>("TripCreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TransportationCarId");

                    b.HasIndex("TripCreatorId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ConfirmationEmailToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ConfirmationEmailTokenExpirationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("HasCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset>("RegistrationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Core.Entities.CarEntity.Car", b =>
                {
                    b.HasOne("Core.Entities.CarCategoryEntity.CarCategory", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.InviteEntity.Invite", b =>
                {
                    b.HasOne("Core.Entities.OfferEntity.Offer", "Offer")
                        .WithOne("Invite")
                        .HasForeignKey("Core.Entities.InviteEntity.Invite", "OfferId");

                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Invites")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("Invites")
                        .HasForeignKey("UserId");

                    b.Navigation("Offer");

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.OfferEntity.Offer", b =>
                {
                    b.HasOne("Core.Entities.RoleEntity.OfferRole", "OfferRole")
                        .WithMany("Offers")
                        .HasForeignKey("CreatorRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.GoodCategoryEntity.GoodCategory", "GoodCategory")
                        .WithMany("Offers")
                        .HasForeignKey("GoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("OfferCreatorId");

                    b.HasOne("Core.Entities.PointEntity.PointData", "Point")
                        .WithMany("Offers")
                        .HasForeignKey("OfferPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Offers")
                        .HasForeignKey("RelatedTripId");

                    b.Navigation("GoodCategory");

                    b.Navigation("OfferRole");

                    b.Navigation("Point");

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.PointEntity.PointData", b =>
                {
                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Points")
                        .HasForeignKey("TripId");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Core.Entities.RatingEntity.Rating", b =>
                {
                    b.HasOne("Core.Entities.UserEntity.User", "EstimatorUser")
                        .WithMany("EstimatorRatings")
                        .HasForeignKey("EstimatorUserId");

                    b.HasOne("Core.Entities.UserEntity.User", "RatedUser")
                        .WithMany("RatedRatings")
                        .HasForeignKey("RatedUserId");

                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Ratings")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimatorUser");

                    b.Navigation("RatedUser");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Core.Entities.RefreshTokenEntity.RefreshToken", b =>
                {
                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.ReportEntity.Report", b =>
                {
                    b.HasOne("Core.Entities.UserEntity.User", "ReportedUser")
                        .WithMany("ViolationReports")
                        .HasForeignKey("ReportedUserId");

                    b.HasOne("Core.Entities.UserEntity.User", "ReporterUser")
                        .WithMany("ReporterReports")
                        .HasForeignKey("ReporterUserId");

                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Reports")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportedUser");

                    b.Navigation("ReporterUser");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Core.Entities.TripEntity.Trip", b =>
                {
                    b.HasOne("Core.Entities.CarEntity.Car", "Car")
                        .WithMany("Trips")
                        .HasForeignKey("TransportationCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("TripCreatorId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.CarCategoryEntity.CarCategory", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Core.Entities.CarEntity.Car", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Core.Entities.GoodCategoryEntity.GoodCategory", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Core.Entities.OfferEntity.Offer", b =>
                {
                    b.Navigation("Invite");
                });

            modelBuilder.Entity("Core.Entities.PointEntity.PointData", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Core.Entities.RoleEntity.OfferRole", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Core.Entities.TripEntity.Trip", b =>
                {
                    b.Navigation("Invites");

                    b.Navigation("Offers");

                    b.Navigation("Points");

                    b.Navigation("Ratings");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("EstimatorRatings");

                    b.Navigation("Invites");

                    b.Navigation("Offers");

                    b.Navigation("RatedRatings");

                    b.Navigation("RefreshTokens");

                    b.Navigation("ReporterReports");

                    b.Navigation("Trips");

                    b.Navigation("ViolationReports");
                });
#pragma warning restore 612, 618
        }
    }
}
