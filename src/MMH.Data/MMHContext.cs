namespace MMH.Data
{
    using System.Data.Entity;
    using MMH.Model.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MMHContext : IdentityDbContext<Advertiser>
    {
        public MMHContext()
            : base("name=MMH")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MMHContext, MMH.Data.Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DonnationAd> DonnationAds { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advertiser>().HasKey(c => c.Id);
            modelBuilder.Entity<Advertiser>().ToTable("Advertiser");
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRole");

        }

        public static MMHContext Create()
        {
            return new MMHContext();
        }
    }
}
