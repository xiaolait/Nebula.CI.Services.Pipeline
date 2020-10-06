using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDbMigrationsContextFactory : IDesignTimeDbContextFactory<PipelineDbMigrationsContext>
    {
        public PipelineDbMigrationsContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PipelineDbMigrationsContext>()
                .UseMySql(configuration.GetConnectionString("mysql"));

            return new PipelineDbMigrationsContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
