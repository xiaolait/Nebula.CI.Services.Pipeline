using System;
namespace Nebula.CI.Services.Pipeline
{
    public class UpdatePipelineStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
    }
}