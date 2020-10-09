using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Nebula.CI.Services.Pipeline
{
    [ConnectionStringName("Pipeline")]
    public class PipelineDbContext : AbpDbContext<PipelineDbContext>
    {
        public DbSet<Pipeline> Pipelines { get; set; }
        public DbSet<User> users { get; set; }

        public PipelineDbContext(DbContextOptions<PipelineDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePipelineStore();
        }
    }
}
