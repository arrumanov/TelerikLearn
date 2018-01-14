using Microsoft.EntityFrameworkCore;

namespace TelerikAspNetCoreApp.EF
{
    public partial class QuickAppContext : DbContext
    {
        public virtual DbSet<AppCustomers> AppCustomers { get; set; }
        public virtual DbSet<AppOrderDetails> AppOrderDetails { get; set; }
        public virtual DbSet<AppOrders> AppOrders { get; set; }
        public virtual DbSet<AppProductCategories> AppProductCategories { get; set; }
        public virtual DbSet<AppProducts> AppProducts { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<OpenIddictApplications> OpenIddictApplications { get; set; }
        public virtual DbSet<OpenIddictAuthorizations> OpenIddictAuthorizations { get; set; }
        public virtual DbSet<OpenIddictScopes> OpenIddictScopes { get; set; }
        public virtual DbSet<OpenIddictTokens> OpenIddictTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=QuickApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppCustomers>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<AppOrderDetails>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.AppOrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AppOrderDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<AppOrders>(entity =>
            {
                entity.HasIndex(e => e.CashierId);

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.AppOrders)
                    .HasForeignKey(d => d.CashierId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AppOrders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<AppProductCategories>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            });

            modelBuilder.Entity<AppProducts>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.ParentId);

                entity.HasIndex(e => e.ProductCategoryId);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Icon)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.AppProducts)
                    .HasForeignKey(d => d.ProductCategoryId);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OpenIddictApplications>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClientId).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<OpenIddictAuthorizations>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Subject).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.OpenIddictAuthorizations)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<OpenIddictScopes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<OpenIddictTokens>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId);

                entity.HasIndex(e => e.AuthorizationId);

                entity.HasIndex(e => e.ReferenceId)
                    .IsUnique()
                    .HasFilter("([ReferenceId] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Subject).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.OpenIddictTokens)
                    .HasForeignKey(d => d.ApplicationId);

                entity.HasOne(d => d.Authorization)
                    .WithMany(p => p.OpenIddictTokens)
                    .HasForeignKey(d => d.AuthorizationId);
            });
        }
    }
}
