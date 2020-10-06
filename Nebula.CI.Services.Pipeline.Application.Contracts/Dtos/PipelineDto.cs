using System;
namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagram { get; set; }
        public string LastStatus { get; set; }
        public string LastSuccessTime { get; set; }
        public string LastFailtureTime { get; set; }
    }

    public enum PipelineStautsDto
    {
        Success,
        Failture
    }
}
