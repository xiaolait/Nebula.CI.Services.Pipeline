using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Nebula.CI.Services.Pipeline
{
    public interface IPipelineAppService : IApplicationService
    {
        Task<List<PipelineDto>> GetListAsync();

        Task<List<PipelineDto>> GetListExampleAsync();

        Task<List<PipelineDto>> GetListTemplateAsync();
        
        Task<PipelineDto> GetAsync(int id);

        Task<PipelineDto> CreateAsync(CreatePipelineDto input);

        Task GetRunAsync(int id, string diagram);

        Task UpdateAsync(UpdatePipelineDiagramDto input);

        Task UpdateInfoAsync(PipelineInfoDto input);

        Task DeleteAsync(int id);
    }
}
