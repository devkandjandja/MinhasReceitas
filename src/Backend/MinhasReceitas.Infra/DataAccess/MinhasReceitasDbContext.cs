using Microsoft.EntityFrameworkCore;
using MinhasReceitas.Domain.Entities;

namespace MinhasReceitas.Infra.DataAccess
{
    public class MinhasReceitasDbContext : DbContext
    {
        public MinhasReceitasDbContext(DbContextOptions options) : base (options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinhasReceitasDbContext).Assembly);
        }
    }
}
