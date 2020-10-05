using System;
namespace Nebula.CI.Services.Pipeline
{
    public class PipelineRunEvent
    {
        public Pipeline Pipeline { get; protected set; }

        public PipelineRunEvent(Pipeline pipeline)
        {
            Pipeline = pipeline;
        }
    }
}
