using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Nebula.CI.Services.Pipeline
{
    public static class PipelineDbContextModelCreatingExtensions
    {
        public static void ConfigurePipelineStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Pipeline>(c =>
            {
                c.ToTable("Pipeline");
                c.ConfigureByConvention();
            });

            builder.Entity<User>(c =>
            {
                c.ToTable("User");
                c.ConfigureByConvention();
            });
        }
    }
}
