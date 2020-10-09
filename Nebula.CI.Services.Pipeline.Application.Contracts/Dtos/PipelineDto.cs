﻿using System;
namespace Nebula.CI.Services.Pipeline
{
    public class PipelineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagram { get; set; }
        public string LastStatus { get; set; }
        public string LastSucceededTime { get; set; }
        public string LastFailedTime { get; set; }
        public int ExecTimes { get; protected set; }
    }
}
