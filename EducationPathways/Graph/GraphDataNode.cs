namespace EducationPathways.Graph
{
    using System;
    using Domain;

    public class GraphDataNode
    {
        public INode Node { get; set; }
        public int NextId { get; set; }
    }
}