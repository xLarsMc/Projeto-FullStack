using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Domain.Repositories;
using Solution.Domain.Repositories.User;
using Solution.Infrastructure.BancoContext;
using Solution.Infrastructure.BancoContext.Repositories;

namespace Solution.Infrastructure
{   public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString)
                       .EnableSensitiveDataLogging()    // Útil para debugar valores nos erros (não usar em produção)
                       .EnableDetailedErrors();         // Habilita mensagens de erro detalhadas
            });
        }


        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }
    }
}
