using System;
namespace Nebula.CI.Services.Pipeline
{
    public class UpdatePipelineStatusDto
    {
        public int Id { get; set; }
        public string LastStatus { get; set; }
        public string LastSucceededTime { get; set; }
        public string LastFailedTime { get; set; }
    }
}