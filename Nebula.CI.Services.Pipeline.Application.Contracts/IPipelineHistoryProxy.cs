using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Nebula.CI.Services.Pipeline
{
    public interface IPipelineHistoryProxy : ITransientDependency
    {
        Task CreateAsync(PipelineDto input);
    }
}
