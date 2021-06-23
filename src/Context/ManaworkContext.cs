using Manawork.Models.User;
using Manawork.Models.Project;
using Microsoft.EntityFrameworkCore;

namespace Manawork.Contxet
{
    public class ManaworkContext : DbContext
    {
        public ManaworkContext(DbContextOptions<ManaworkContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<Project>()
                .HasQueryFilter(p => !p.IsDelete);

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);
        }
    }
}