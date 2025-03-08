using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets das suas entidades
        //public DbSet<Cliente> Clientes { get; set; }
        // Adicione outros DbSets conforme necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais do modelo, se necessário
        }
    }
}

