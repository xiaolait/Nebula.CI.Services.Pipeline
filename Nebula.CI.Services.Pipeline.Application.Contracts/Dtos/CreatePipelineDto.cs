using System;
namespace Nebula.CI.Services.Pipeline
{
    public class CreatePipelineDto
    {
        public string Name { get; set; }
        public string Diagram { get; set; }
    }
}
