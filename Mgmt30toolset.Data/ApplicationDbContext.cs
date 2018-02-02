using Mgmt30toolset.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mgmt30toolset.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Kudo> Kudos { get; set; }
        public DbSet<KudoCategory> KudoCategories { get; set; }
        public DbSet<EduPoint> EduPoints { get; set; }
        public DbSet<EduPointCategory> EduPointCategories { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<BonusTag> BonusTags { get; set; }

        public virtual void CommitChanges()
        {
            base.SaveChanges();
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = builder.UseSqlite("Data Source=mgmt30toolset.db", b => b.MigrationsAssembly("Mgmt30toolset.Web"));
            return new ApplicationDbContext(options.Options);
        }
    }
}
