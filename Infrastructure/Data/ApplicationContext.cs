﻿using Core.Entities.CarCategoryEntity;
using Core.Entities.CarEntity;
using Core.Entities.GoodCategoryEntity;
using Core.Entities.OfferEntity;
using Core.Entities.PointEntity;
using Core.Entities.RatingEntity;
using Core.Entities.ReportEntity;
using Core.Entities.RoleEntity;
using Core.Entities.TripEntity;
using Core.Entities.UserEntity;
using Core.Entities.RefreshTokenEntity;
using Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Entities.InviteEntity;
using Core.Entities.NotificationEntity;

namespace Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public DbSet<OfferRole> OfferRoles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PointData> Points { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<GoodCategory> GoodCategories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new OfferConfiguration());
            builder.ApplyConfiguration(new GoodCategoryConfiguration());
            builder.ApplyConfiguration(new PointConfiguration());
            builder.ApplyConfiguration(new ReportConfiguration());
            builder.ApplyConfiguration(new OfferRoleConfiguration());
            builder.ApplyConfiguration(new CarCategoryConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TripConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new RefreshTokenConfiguration());
            builder.ApplyConfiguration(new InviteConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
