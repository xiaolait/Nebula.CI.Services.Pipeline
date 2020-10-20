using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nebula.CI.Services.Pipeline
{
    public static class PipelineValidationExtensions
    {
        public static bool IsDiagramAvailable(this Pipeline pipeline)
        {
            if (string.IsNullOrEmpty(pipeline.Diagram)) return false;
            var diagram = JsonConvert.DeserializeObject<Digram>(pipeline.Diagram);
            if (diagram.NodeList == null || diagram.NodeList.Count == 0) return false;
            else return true;
        }

        internal class Digram
        {
            public string Name { get; set; }
            public List<Node> NodeList { get; set; } = new List<Node>();

            public class Node
            {
                public string Id { get; set; }
            }
        }
    }
}