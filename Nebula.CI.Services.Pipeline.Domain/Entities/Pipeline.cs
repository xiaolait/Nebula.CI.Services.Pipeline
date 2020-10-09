using System;
using Volo.Abp.Domain.Entities;

namespace Nebula.CI.Services.Pipeline
{
    public class Pipeline : AggregateRoot<int>
    {
        public string Name { get; protected set; }
        public string Diagram { get; protected set; }
        public string LastStatus { get; protected set; }
        public string LastSucceededTime { get; protected set; }
        public string LastFailedTime { get; protected set; }
        public int ExecTimes { get; protected set; }
        public int UserId { get; protected set; }

        protected Pipeline()
        {

        }

        public Pipeline(string name, int userId, string diagram = null)
        {
            Name = name;
            Diagram = diagram;
            UserId = userId;
        }

        public Pipeline SetName(string name)
        {
            Name = name;
            return this;
        }

        public Pipeline SetDiagram(string diagram)
        {
            Diagram = diagram;
            return this;
        }

        public Pipeline Run()
        {
            ExecTimes++;
            AddLocalEvent(new PipelineRunEvent(this));
            return this;
        }
    }
}