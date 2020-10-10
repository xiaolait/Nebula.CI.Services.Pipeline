using System;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Nebula.CI.Services.Pipeline
{
    [DependsOn(typeof(AbpBackgroundJobsModule))]
    public class PipelineBackgroundModule : AbpModule
    {

    }
}