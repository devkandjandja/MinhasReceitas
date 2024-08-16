using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhasReceitas.Domain.Enums;
using MinhasReceitas.Domain.Repositories;
using MinhasReceitas.Domain.Repositories.User;
using MinhasReceitas.Infra.DataAccess;
using MinhasReceitas.Infra.DataAccess.Repositories;

namespace MinhasReceitas.Infra
{
    public static class DependencyInjectionExtension 
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseType = configuration.GetConnectionString("DatabaseType");

            var databaseTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType!);

            if (databaseTypeEnum == DatabaseType.SqlServer)
                AddDbContextSqlServer(services, configuration);
            else
                AddDbContextMySqlServer(services, configuration);

            AddRepositories(services);
        }
        private static void AddDbContextSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionSqlServer");
            services.AddDbContext<MinhasReceitasDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddDbContextMySqlServer(IServiceCollection services, IConfiguration configuration)
        {
            //Falta instalar recurso para mySql
            var connectionString = configuration.GetConnectionString("ConnectionMySql");
           // var serveVersion = new MySqlServerVersion(new Version(8, 0, 35));
            services.AddDbContext<MinhasReceitasDbContext>(dbContextOptions =>
            {
               // dbContextOptions.UseMySql(connectionString, serveVersion);
            });
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
