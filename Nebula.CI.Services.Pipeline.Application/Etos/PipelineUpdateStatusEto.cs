using Volo.Abp.EventBus;

namespace Nebula.CI.Services.Pipeline
{
    [EventName("PipelineUpdateStatus")]
    public class PipelineUpdateStatusEto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
    }
}