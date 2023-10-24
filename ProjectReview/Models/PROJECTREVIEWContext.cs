using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectReview.Models
{
    public partial class PROJECTREVIEWContext : DbContext
    {
        public PROJECTREVIEWContext()
        {
        }

        public PROJECTREVIEWContext(DbContextOptions<PROJECTREVIEWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<LocationImg> LocationImgs { get; set; } = null!;
        public virtual DbSet<LocationStatus> LocationStatuses { get; set; } = null!;
        public virtual DbSet<LocationType> LocationTypes { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Rate> Rates { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public virtual DbSet<Village> Villages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.LikeNumber).HasColumnName("likeNumber");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Comment_Location");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_District_City");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Coordinates).HasColumnName("coordinates");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("createDate");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.VillageId).HasColumnName("villageID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Location_LocationStatus");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Location_LocationType");

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.VillageId)
                    .HasConstraintName("FK_Location_Village");
            });

            modelBuilder.Entity<LocationImg>(entity =>
            {
                entity.ToTable("LocationImg");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationImgs)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_LocationImg_Location");
            });

            modelBuilder.Entity<LocationStatus>(entity =>
            {
                entity.ToTable("LocationStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.ToUserId).HasColumnName("toUserID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MessageToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_Message_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessageUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.ToTable("Rate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Rate_Location");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reply");

                entity.Property(e => e.CommentId).HasColumnName("commentID");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LikeNumber).HasColumnName("likeNumber");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Comment)
                    .WithMany()
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Reply_Comment");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_User_UserStatus");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Village>(entity =>
            {
                entity.ToTable("Village");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("districtID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Villages)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Village_District");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
