using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDeletedHandler : ILocalEventHandler<EntityDeletedEventData<Pipeline>>, ITransientDependency
    {
        public async Task HandleEventAsync(EntityDeletedEventData<Pipeline> eventData)
        {
            Console.WriteLine($"pipeline:{eventData.Entity.Id} is deleted");
        }
    }
}
