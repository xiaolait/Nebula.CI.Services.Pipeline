using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Nebula.CI.Services.Pipeline
{
    public class EFCorePipelineDbSchemaMigrator : ITransientDependency
    {
        private readonly PipelineDbMigrationsContext _dbContext;

        public EFCorePipelineDbSchemaMigrator(PipelineDbMigrationsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
