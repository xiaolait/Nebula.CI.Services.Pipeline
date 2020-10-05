using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineRunHandler : ILocalEventHandler<PipelineRunEvent>, ITransientDependency
    {

        public async Task HandleEventAsync(PipelineRunEvent eventData)
        {
            await Task.Delay(100);
            Console.WriteLine($"create new pipelinehistory:{eventData.Pipeline.Name}");
        }
    }
}
