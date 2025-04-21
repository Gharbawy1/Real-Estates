using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace real_estate.Models.ApplicationContext
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  تحديد العلاقة بين Owner و Property
            //modelBuilder.Entity<RealEstate>()
            //    .HasOne(p => p.Owner) // كل Property لديه مالك واحد
            //    .WithMany(o => o.RealEstates) // كل Owner يملك عدة RealEstates
            //    .HasForeignKey(p => p.OwnerId) // المفتاح الأجنبي في جدول Property
            //    .OnDelete(DeleteBehavior.Cascade); // لو حذفنا المالك، نحذف كل عقاراته

            


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<EstateType> EstateTypes { get; set; }
        public DbSet<RealEstateImage> RealEstateImages { get; set; }
    }
}
