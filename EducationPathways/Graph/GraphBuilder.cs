namespace EducationPathways.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;

    public class GraphBuilder
    {
        public int RootNodeId { get; private set; }
        public IDictionary<int, IList<GraphDataNode>> Nodes { get; private set; }

        public GraphBuilder(int rootNodeId)
        {
            RootNodeId = rootNodeId;
            Nodes = new Dictionary<int, IList<GraphDataNode>>();
        }

        public INode Build()
        {
            foreach (var kv in Nodes)
            {
                foreach (var gdn in kv.Value.Where(x => x.NextId > 0))
                {
                    var nextNodes = GetNode(gdn.NextId);
                    
                    if (gdn.Node.NextNodes == null)
                        gdn.Node.NextNodes = new List<INode>();

                    foreach (var nextNode in nextNodes)
                        gdn.Node.NextNodes.Add(nextNode.Node);
                }
            }

            return GetNode(RootNodeId).Single().Node;
        }

        private IEnumerable<GraphDataNode> GetNode(int nodeId)
        {
            IList<GraphDataNode> gdns;
            if (Nodes.TryGetValue(nodeId, out gdns))
                return gdns;

            throw new InvalidOperationException(string.Format("Node {0} does not exist.", nodeId));
        }
    }
}
