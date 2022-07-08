using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FoodOrder.Entity.Entities;

#nullable disable

namespace FoodOrder.Entity.Contexts
{
    public partial class FoodOrderContext : DbContext
    {
        public FoodOrderContext()
        {
        }

        public FoodOrderContext(DbContextOptions<FoodOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgenciesUser> AgenciesUsers { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<RefRole> RefRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DATLUONG-PC\\DATL;Initial Catalog=FoodOrder;Persist Security Info=True;User ID=dl_food_order;Password=dl@123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AgenciesUser>(entity =>
            {
                entity.HasKey(e => e.AgencyUserNo)
                    .HasName("PK__Agencies__665BD69DA52F4ED8");

                entity.HasOne(d => d.AgencyNoNavigation)
                    .WithMany(p => p.AgenciesUsers)
                    .HasForeignKey(d => d.AgencyNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_agency_user");

                entity.HasOne(d => d.UserNoNavigation)
                    .WithMany(p => p.AgenciesUsers)
                    .HasForeignKey(d => d.UserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_agency");
            });

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.HasKey(e => e.AgencyNo);

                entity.Property(e => e.AgencyCompanyName).HasMaxLength(60);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RefRole>(entity =>
            {
                entity.HasKey(e => e.RoleNo)
                    .HasName("PK__RefRoles__8AFAE645577C0569");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserNo)
                    .HasName("PK__Users__1788955FDAFB5774");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.PasswordPin)
                    .HasMaxLength(64)
                    .HasColumnName("PasswordPIN");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasKey(e => e.UsersRoleNo)
                    .HasName("PK__UsersRol__E3DDCD5EE642B9AF");

                entity.HasOne(d => d.RoleNoNavigation)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role_user");

                entity.HasOne(d => d.UserNoNavigation)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
