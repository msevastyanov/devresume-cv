using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevResume.Infrastructure.Configuration
{
    public class DbConfig
    {
        static string _connectionString;

        public static string ConnectionString => _connectionString;

        public static void ConfigureDb(IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DevResume.Application")));
        }
    }
}