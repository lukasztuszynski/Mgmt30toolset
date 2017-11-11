using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Triggers;

namespace Mgmt30toolset.Models
{
    public class ApplicationDbContext : DbContextWithTriggers
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Kudo> Kudos { get; set; }
        public DbSet<KudoCategory> KudoCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<BonusTag> BonusTags { get; set; }
    }
}
