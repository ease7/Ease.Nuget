using Microsoft.EntityFrameworkCore;
using Synyi.CaseCode.Configuration.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synyi.CaseCode.Configuration
{
    public class ConfigurationDbContext : DbContext
    {
        public string DefaultSchema { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options
            , DbConfigurationContextExtension extension = null) : base(options)
        {
            if(extension != null)
                this.DefaultSchema = extension.Schema;
        }

        /// <summary>
        /// 系统配置项
        /// </summary>
        public DbSet<SystemConfiguration> DbConfiguration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemConfiguration>().ToTable("sys_configuration", DefaultSchema);
        }
    }
}
