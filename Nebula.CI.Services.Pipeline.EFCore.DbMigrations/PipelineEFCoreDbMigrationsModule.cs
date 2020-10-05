using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineEFCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PipelineDbMigrationsContext>();
        }
    }
}
