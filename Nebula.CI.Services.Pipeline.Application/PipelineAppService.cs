﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineAppService : ApplicationService, IPipelineAppService
    {
        private readonly IRepository<Pipeline, int> _pipelineRepository;
        private readonly IUserAppService _userAppService;
        private readonly IServiceProvider _serviceProvider;

        public PipelineAppService(IRepository<Pipeline, int> pipelineRepository, IUserAppService userAppService, IServiceProvider serviceProvider)
        {
            _pipelineRepository = pipelineRepository;
            _userAppService = userAppService;
            _serviceProvider = serviceProvider;
        }

        [Authorize]
        public async Task<PipelineDto> CreateAsync(CreatePipelineDto input)
        {
            var userId = await _userAppService.GetUserId();
            var pipeline = await _pipelineRepository.InsertAsync(
                new Pipeline(input.Name, userId, input.Diagram)
            );
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Pipeline, PipelineDto>(pipeline);
        }

        public async Task CreateRunAsync(int id, string diagram)
        {
            var pipeline = await _pipelineRepository.GetAsync(id);
            if (!pipeline.IsDiagramAvailable()) return;

            pipeline.Run();
            var pipelineDto = ObjectMapper.Map<Pipeline, PipelineDto>(pipeline);
            pipelineDto.Diagram = diagram??pipelineDto.Diagram;

            var pipelineHistoryProxy = _serviceProvider.GetService(typeof(IPipelineHistoryProxy)) as IPipelineHistoryProxy;
            await pipelineHistoryProxy.CreateAsync(pipelineDto);
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

        [Authorize]
        public async Task<List<PipelineDto>> GetListAsync()
        {
            var userId = await _userAppService.GetUserId();

            var pipelines = await _pipelineRepository.Where(s => s.UserId == userId).ToListAsync();

            var pipelineList = ObjectMapper.Map<List<Pipeline>, List<PipelineDto>>(pipelines);

            return pipelineList;
        }

        public async Task UpdateAsync(UpdatePipelineDiagramDto input)
        {
            var pipeline = await _pipelineRepository.GetAsync(input.Id);

            pipeline.SetName(input.Name);
            pipeline.SetDiagram(input.Diagram);
        }

        public async Task UpdateStatusAsync(UpdatePipelineStatusDto input)
        {
            var pipeline = await _pipelineRepository.GetAsync(input.Id);
            pipeline.SetStatus(input.Status, input.Time);
        }
    }
}
