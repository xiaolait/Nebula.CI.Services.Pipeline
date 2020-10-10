using System;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineHistoryCreatedJob : BackgroundJob<PipelineDto>, ITransientDependency
    {

        public IPipelineHistoryProxy PipelineHistoryProxy { get; set; }

        public override void Execute(PipelineDto args)
        {
            PipelineHistoryProxy?.CreateAsync(args).Wait();
        }
    }
}

