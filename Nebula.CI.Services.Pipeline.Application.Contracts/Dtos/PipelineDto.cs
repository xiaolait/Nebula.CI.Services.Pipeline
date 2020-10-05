using System;
namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagram { get; set; }
        public string LastStauts { get; set; }
        public DateTime LastSuccessTime { get; set; }
        public DateTime LastFailtureTime { get; set; }
    }

    public enum PipelineStautsDto
    {
        Success,
        Failture
    }
}
