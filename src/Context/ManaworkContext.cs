using Manawork.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Manawork.Contxet
{
    public class ManaworkContext : DbContext
    {
        public ManaworkContext(DbContextOptions<ManaworkContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}