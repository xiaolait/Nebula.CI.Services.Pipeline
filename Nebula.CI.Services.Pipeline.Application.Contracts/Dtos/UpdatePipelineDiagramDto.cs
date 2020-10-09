using System;
namespace Nebula.CI.Services.Pipeline
{
    public class UpdatePipelineDiagramDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagram { get; set; }
    }
}