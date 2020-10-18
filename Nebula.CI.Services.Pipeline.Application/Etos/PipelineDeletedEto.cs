using System;
using Volo.Abp.EventBus;

namespace Nebula.CI.Services.Pipeline
{
    [EventName("PipelineDeleted")]
    public class PipelineDeletedEto
    {
        public int Id { get; set; }
    }
}