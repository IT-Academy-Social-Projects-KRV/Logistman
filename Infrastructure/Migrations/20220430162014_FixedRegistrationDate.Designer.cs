﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220430162014_FixedRegistrationDate")]
    partial class FixedRegistrationDate
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

                    b.Property<string>("Vin")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

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

            modelBuilder.Entity("Core.Entities.OfferEntity.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatorRoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ExpirationDate")
                        .HasColumnType("datetimeoffset");

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

            modelBuilder.Entity("Core.Entities.PointEntity.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Settlement")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Core.Entities.TripEntity.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
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

            modelBuilder.Entity("PointTrip", b =>
                {
                    b.Property<int>("PointsId")
                        .HasColumnType("int");

                    b.Property<int>("TripsId")
                        .HasColumnType("int");

                    b.HasKey("PointsId", "TripsId");

                    b.HasIndex("TripsId");

                    b.ToTable("PointTrip");
                });

            modelBuilder.Entity("Core.Entities.RoleEntity.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

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

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Entities.OfferEntity.Offer", b =>
                {
                    b.HasOne("Core.Entities.RoleEntity.Role", "Role")
                        .WithMany("Offers")
                        .HasForeignKey("CreatorRoleId");

                    b.HasOne("Core.Entities.GoodCategoryEntity.GoodCategory", "GoodCategory")
                        .WithMany("Offers")
                        .HasForeignKey("GoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("OfferCreatorId");

                    b.HasOne("Core.Entities.PointEntity.Point", "Point")
                        .WithMany("Offers")
                        .HasForeignKey("OfferPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TripEntity.Trip", "Trip")
                        .WithMany("Offers")
                        .HasForeignKey("RelatedTripId");

                    b.Navigation("GoodCategory");

                    b.Navigation("Point");

                    b.Navigation("Role");

                    b.Navigation("Trip");

                    b.Navigation("User");
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

            modelBuilder.Entity("PointTrip", b =>
                {
                    b.HasOne("Core.Entities.PointEntity.Point", null)
                        .WithMany()
                        .HasForeignKey("PointsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TripEntity.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
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

            modelBuilder.Entity("Core.Entities.PointEntity.Point", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Core.Entities.TripEntity.Trip", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Ratings");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Core.Entities.RoleEntity.Role", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Core.Entities.UserEntity.User", b =>
                {
                    b.Navigation("EstimatorRatings");

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
