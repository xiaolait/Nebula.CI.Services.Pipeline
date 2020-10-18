using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDeletedHandler : ILocalEventHandler<EntityDeletedEventData<Pipeline>>, ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public PipelineDeletedHandler(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public async Task HandleEventAsync(EntityDeletedEventData<Pipeline> eventData)
        {
            Console.WriteLine($"pipeline:{eventData.Entity.Id} is deleted");
            await _distributedEventBus.PublishAsync(new PipelineDeletedEto { Id = eventData.Entity.Id });
        }
    }
}
