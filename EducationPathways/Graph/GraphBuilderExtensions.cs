namespace EducationPathways.Graph
{
    using System;
    using System.Collections.Generic;
    using Domain;

    public static class GraphBuilderExtensions
    {
        public static GraphBuilder Add(this GraphBuilder builder, int id, INode node, int nextId = 0)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException("id");

            var gdn = new GraphDataNode { Node = node, NextId = nextId };

            IList<GraphDataNode> gdns;
            if (builder.Nodes.TryGetValue(id, out gdns))
            {
                gdns.Add(gdn);
            }
            else
            {
                builder.Nodes.Add(id, new List<GraphDataNode> { gdn });
            }

            return builder;
        }
    }
}
