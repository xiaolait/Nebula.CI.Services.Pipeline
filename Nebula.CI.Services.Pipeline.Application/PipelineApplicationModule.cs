using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Nebula.CI.Services.Pipeline
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class PipelineApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<PipelineApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
