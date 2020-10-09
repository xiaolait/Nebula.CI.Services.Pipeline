using System;
using System.Threading.Tasks;
using AutoMapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.ObjectMapping;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineRunHandler : ILocalEventHandler<PipelineRunEvent>, ITransientDependency
    {
        private readonly IObjectMapper<PipelineApplicationModule> _objectMapper;
        private readonly IPipelineHistoryProxy _pipelineHistoryProxy;

        public PipelineRunHandler(IObjectMapper<PipelineApplicationModule> objectMapper, IPipelineHistoryProxy pipelineHistoryProxy = null)
        {
            _objectMapper = objectMapper;
            _pipelineHistoryProxy = pipelineHistoryProxy;
        }

        public async Task HandleEventAsync(PipelineRunEvent eventData)
        {
            var pipelineDto = _objectMapper.Map<Pipeline, PipelineDto>(eventData.Pipeline);
            await _pipelineHistoryProxy?.CreateAsync(pipelineDto);

            Console.WriteLine("Create new PipelineHistory");
        }
    }
}
