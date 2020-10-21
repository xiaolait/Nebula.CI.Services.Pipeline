using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineUpdateStatusHandler : IDistributedEventHandler<PipelineUpdateStatusEto>, ITransientDependency
    {
        private readonly IRepository<Pipeline, int> _pipelineRepository;

        public PipelineUpdateStatusHandler(IRepository<Pipeline, int> pipelineRepository)
        {
            _pipelineRepository = pipelineRepository;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(PipelineUpdateStatusEto eventData)
        {
            Console.WriteLine($"pipeline:{eventData.Id} status is updated");
            var pipeline = await _pipelineRepository.GetAsync(eventData.Id);
            pipeline.SetStatus(eventData.Status, eventData.Time);
        }
    }
}