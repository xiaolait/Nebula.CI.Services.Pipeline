using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Nebula.CI.Services.Pipeline
{
    [ConnectionStringName("mysql")]
    public class PipelineDbMigrationsContext : AbpDbContext<PipelineDbMigrationsContext>
    {
        public PipelineDbMigrationsContext(DbContextOptions<PipelineDbMigrationsContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */
            builder.ConfigurePipelineStore();
        }
    }
}
