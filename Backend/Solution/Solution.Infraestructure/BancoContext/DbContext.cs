using Microsoft.EntityFrameworkCore;
using Solution.Domain.Entities;

namespace Solution.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // DbSets das suas entidades
        //public DbSet<Cliente> Clientes { get; set; }
        // Adicione outros DbSets conforme necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

