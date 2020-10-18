using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Nebula.CI.Services.Pipeline.Application.DomainEventHandlers
{
    public class PipelineCreatedHandler : ILocalEventHandler<EntityCreatedEventData<Pipeline>>, ITransientDependency
    {
        public async Task HandleEventAsync(EntityCreatedEventData<Pipeline> eventData)
        {
            Console.WriteLine($"pipeline:{eventData.Entity.Id} is deleted");
        }
    }
}
