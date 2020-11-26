using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Users;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineAppService : ApplicationService, IPipelineAppService
    {
        private readonly IRepository<Pipeline, int> _pipelineRepository;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly ICurrentUser _currentUser;

        public PipelineAppService(
            IRepository<Pipeline, int> pipelineRepository, 
            IDistributedEventBus distributedEventBus, 
            ICurrentUser currentUser)
        {
            _pipelineRepository = pipelineRepository;
            _distributedEventBus = distributedEventBus;
            _currentUser = currentUser;
        }

        [Authorize]
        public async Task<PipelineDto> CreateAsync(CreatePipelineDto input)
        {
            var userId = _currentUser.FindClaimValue("sub");
            var userName = _currentUser.FindClaimValue("name");
            var pipeline = await _pipelineRepository.InsertAsync(
                new Pipeline(input.Name, userId, userName, input.Diagram)
            );
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Pipeline, PipelineDto>(pipeline);
        }

        public async Task CreateRunAsync(int id, string diagram)
        {
            await Run(id, diagram);
        }

        public async Task GetRunAsync(int id, string diagram)
        {
            await Run(id, diagram);
        }

        public async Task DeleteAsync(int id)
        {
            await _pipelineRepository.DeleteAsync(id);
        }

        public async Task<PipelineDto> GetAsync(int id)
        {
            var pipeline = await _pipelineRepository.GetAsync(id);

            return ObjectMapper.Map<Pipeline, PipelineDto>(pipeline);
        }

        public async Task<PipelineInfoDto> GetInfoAsync(int id)
        {
            var pipeline = await _pipelineRepository.GetAsync(id);

            return ObjectMapper.Map<Pipeline, PipelineInfoDto>(pipeline);
        }

        [Authorize]
        public async Task<List<PipelineDto>> GetListAsync()
        {
            var userId = _currentUser.FindClaimValue("sub");

            var pipelines = await _pipelineRepository.Where(s => s.UserId == userId).ToListAsync();

            var pipelineList = ObjectMapper.Map<List<Pipeline>, List<PipelineDto>>(pipelines);

            return pipelineList;
        }

        public async Task<List<PipelineDto>> GetListExampleAsync()
        {
            var pipelines = await _pipelineRepository.Where(s => s.UserName == "example").ToListAsync();

            var pipelineList = ObjectMapper.Map<List<Pipeline>, List<PipelineDto>>(pipelines);

            return pipelineList;
        }

        public async Task<List<PipelineDto>> GetListTemplateAsync()
        {
            var pipelines = await _pipelineRepository.Where(s => s.UserName == "template").ToListAsync();

            var pipelineList = ObjectMapper.Map<List<Pipeline>, List<PipelineDto>>(pipelines);

            return pipelineList;
        }

        public async Task UpdateAsync(UpdatePipelineDiagramDto input)
        {
            var pipeline = await _pipelineRepository.GetAsync(input.Id);

            pipeline.SetName(input.Name);
            pipeline.SetDiagram(input.Diagram);
        }

        public async Task UpdateInfoAsync(PipelineInfoDto input)
        {
            var pipeline = await _pipelineRepository.GetAsync(input.Id);
            foreach (PropertyInfo p in input.GetType().GetProperties())
            {
                pipeline.SetProperty<string>(p.Name, p.GetValue(input));
            }
            
        }

        private async Task Run(int id, string diagram)
        {
            var pipeline = await _pipelineRepository.GetAsync(id);
            if (pipeline == null) return;

            var execDiagram = diagram??pipeline.Diagram;
            if (!execDiagram.IsDiagramAvailable()) return;

            pipeline.Run();
            await _distributedEventBus.PublishAsync(new PipelineRunEto(){
                No = pipeline.ExecTimes,
                Diagram = diagram??pipeline.Diagram,
                PipelineName = pipeline.Name,
                PipelineId = pipeline.Id,
                UserId = pipeline.UserId
            });
        }

    }
}
