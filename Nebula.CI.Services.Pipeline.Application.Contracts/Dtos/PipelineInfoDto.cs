using System;

namespace Nebula.CI.Services.Pipeline
{
    public class PipelineInfoDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string SoftwareName { get; set; }
        public string SoftwareShort { get; set; }
        public string SoftwareCode { get; set; }
        public string SoftwareLevel { get; set; }
        public string BelongedSystem { get; set; }
        public string RunEnvironment { get; set; }
        public string DevelopDepartment { get; set; }
        public string ProjectChief { get; set; }
        public string ChiefDesigner { get; set; }
        public string Developer { get; set; }
    }
}