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
    }
}