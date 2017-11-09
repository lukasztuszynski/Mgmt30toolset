using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
