using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nebula.CI.Services.Pipeline
{
    public static class DiagramValidationExtensions
    {
        public static bool IsDiagramAvailable(this string diagram)
        {
            if (string.IsNullOrEmpty(diagram)) return false;
            var diagramModel = JsonConvert.DeserializeObject<Digram>(diagram);
            if (diagramModel.NodeList == null || diagramModel.NodeList.Count == 0) return false;
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