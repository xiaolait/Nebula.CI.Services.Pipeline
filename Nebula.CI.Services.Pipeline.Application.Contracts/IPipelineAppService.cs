using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Nebula.CI.Services.Pipeline
{
    public interface IPipelineAppService : IApplicationService
    {
        Task<List<PipelineDto>> GetListAsync();

        Task<PipelineDto> GetAsync(int id);

        Task<PipelineDto> CreateAsync(CreatePipelineDto input);

        Task CreateRunAsync(int id, string diagram);

        Task UpdateAsync(UpdatePipelineDiagramDto input);
        Task UpdateStatusAsync(UpdatePipelineStatusDto input);

        Task DeleteAsync(int id);
    }
}
