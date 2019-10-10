using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synyi.CaseCode.Configuration
{
    public static class DbConfigurationExtensions
    {
        public static void AddDbConfiguration(this IServiceCollection services, Action<DbContextOptionsBuilder> builder, string schema)
        {
            services.AddSingleton(new DbConfigurationContextExtension(schema));
            services.AddDbContext<ConfigurationDbContext>(builder);
            services.AddSingleton<IDbConfiguration, DbConfiguration>();
        }

        public static void AddDbConfiguration(this IServiceCollection services, string connectionString, string schema)
        {
            services.AddSingleton(new DbConfigurationContextExtension(schema));
            services.AddDbContext<ConfigurationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddSingleton<IDbConfiguration, DbConfiguration>();
        }

        
    }
}
