using InterviewProject.Application.Interfaces;
using InterviewProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Domain.Exceptions;

namespace InterviewProject.Application.Common
{
    public class GraphPathFinder : IGraphPathFinder
    {
        public List<IGraphNode> FindShortestPath(IGraphNode start, IGraphNode target, List<IGraphNode> nodes)
        {
            var nodeStats = AnalyseGraph(start, target, nodes);
            var path = GetPatch(start, target, nodeStats);
            return path;
        }

        private Dictionary<IGraphNode, NodeStats> AnalyseGraph(IGraphNode start, IGraphNode destination, List<IGraphNode> nodes)
        {
            Queue<IGraphNode> queue = new Queue<IGraphNode>();

            Dictionary<IGraphNode, NodeStats> nodesStats = new Dictionary<IGraphNode, NodeStats>();

            nodes.ForEach(country =>
            {
                nodesStats.Add(country, new NodeStats());
            });

            queue.Enqueue(start);

            nodesStats[start].Processed = true;

            nodesStats[start].DistanceTo = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                current.Connections.ToList().ForEach(connection =>
                {
                    var neighbour = connection.Target;
                    if (nodesStats[neighbour].Processed == false)
                    {
                        queue.Enqueue(neighbour);

                        nodesStats[neighbour].Processed = true;
                        nodesStats[neighbour].DistanceTo = nodesStats[current].DistanceTo + 1;
                        nodesStats[neighbour].PreviousNode = current;
                    }
                });
            }
            return nodesStats;
        }

        private List<IGraphNode> GetPatch(IGraphNode start, IGraphNode destination, Dictionary<IGraphNode, NodeStats> nodesStats)
        {
            List<IGraphNode> path = new List<IGraphNode>();

            var current = destination;
            path.Add(destination);
            while (nodesStats[current].PreviousNode != null)
            {
                current = nodesStats[current].PreviousNode;
                path.Add(current);
            }
            path.Reverse();

            if (path.Count == 0 || path[0] != start) throw new PathNotFoundException(start.Value, destination.Value);

            return path;
        }


        private class NodeStats
        {
            public IGraphNode PreviousNode { get; set; }
            public int DistanceTo { get; set; }
            public bool Processed { get; set; }

            public NodeStats()
            {
                PreviousNode = null;
                DistanceTo = Int32.MaxValue;
                Processed = false;
            }
        }
    }
}
