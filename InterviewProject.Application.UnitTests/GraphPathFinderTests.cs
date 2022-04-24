using InterviewProject.Application.Common;
using InterviewProject.Application.Interfaces;
using InterviewProject.Domain.Common;
using InterviewProject.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace InterviewProject.Application.UnitTests
{
    [TestFixture]
    internal class GraphPathFinderTests
    {
        private IGraphPathFinder graphPathFinder;
        private List<IGraphNode> nodes;
        [SetUp]
        public void SetUp()
        {
            graphPathFinder = new GraphPathFinder();

            var A = new GraphNode("A");
            var B = new GraphNode("B");
            var C = new GraphNode("C");
            var D = new GraphNode("D");
            var E = new GraphNode("E");
            var F = new GraphNode("F");
            var G = new GraphNode("G");
            var H = new GraphNode("H");
            var I = new GraphNode("I");

            //cycic graph
            A.Connections = new List<IGraphEdge>
            {
                new GraphEdge(B),
                new GraphEdge(C)
            };

            B.Connections = new List<IGraphEdge>
            {
                new GraphEdge(A),
                new GraphEdge(C)
            };

            C.Connections = new List<IGraphEdge>
            {
                new GraphEdge(A),
                new GraphEdge(C)
            };

            //acyclic graph

            D.Connections = new List<IGraphEdge>
            {
                new GraphEdge(E)
            };

            E.Connections = new List<IGraphEdge>
            {
                new GraphEdge(D),
                new GraphEdge(F)
            };

            F.Connections = new List<IGraphEdge>
            {
                new GraphEdge(E),
                new GraphEdge(G),
                new GraphEdge(H)
            };

            H.Connections = new List<IGraphEdge>
            {
                new GraphEdge(F),
                new GraphEdge(I)
            };

            G.Connections = new List<IGraphEdge>
            {
                new GraphEdge(F)
            };

            I.Connections = new List<IGraphEdge>
            {
                new GraphEdge(H)
            };

            nodes = new List<IGraphNode>
            {
                A,B,C,D,E,F,G,H,I
            };
        }

        [Test]
        public void FindShortestPath_AC_AC()
        {
            var start = nodes.Find(n => n.Value == "A");

            var destination = nodes.Find(n => n.Value == "C");


            var actual = graphPathFinder.FindShortestPath(start, destination, nodes);

            var expeced = new List<GraphNode>
            {
                new GraphNode("A"),
                new GraphNode("C")
            };

            Assert.That(actual, Is.EquivalentTo(expeced));
        }

        [Test]
        public void FindShortestPath_AB_AB()
        {
            var start = nodes.Find(n => n.Value == "A");

            var destination = nodes.Find(n => n.Value == "B");


            var actual = graphPathFinder.FindShortestPath(start, destination, nodes);

            var expeced = new List<GraphNode>
            {
                new GraphNode("A"),
                new GraphNode("B")
            };

            Assert.That(actual, Is.EquivalentTo(expeced));
        }

        [Test]
        public void FindShortestPath_AD_ThrowsPathNotFoundException()
        {
            var start = nodes.Find(n => n.Value == "A");

            var destination = nodes.Find(n => n.Value == "D");

            Assert.Throws<PathNotFoundException>(() =>
            {
                graphPathFinder.FindShortestPath(start, destination, nodes);
            });
        }
        [Test]
        public void FindShortestPath_AA_A()
        {
            var start = nodes.Find(n => n.Value == "A");

            var destination = nodes.Find(n => n.Value == "A");


            var actual = graphPathFinder.FindShortestPath(start, destination, nodes);

            var expeced = new List<GraphNode>
            {
                new GraphNode("A"),
            };

            Assert.That(actual, Is.EquivalentTo(expeced));
        }

        [Test]
        public void FindShortestPath_DI_DEFHI()
        {
            var start = nodes.Find(n => n.Value == "D");

            var destination = nodes.Find(n => n.Value == "I");

            var actual = graphPathFinder.FindShortestPath(start, destination, nodes);

            var expeced = new List<GraphNode>
            {
                new GraphNode("D"),
                new GraphNode("E"),
                new GraphNode("F"),
                new GraphNode("H"),
                new GraphNode("I"),
            };

            Assert.That(actual, Is.EquivalentTo(expeced));
        }

        [Test]
        public void FindShortestPath_GD_DFED()
        {
            var start = nodes.Find(n => n.Value == "G");

            var destination = nodes.Find(n => n.Value == "D");

            var actual = graphPathFinder.FindShortestPath(start, destination, nodes);

            var expeced = new List<GraphNode>
            {
                new GraphNode("G"),
                new GraphNode("F"),
                new GraphNode("E"),
                new GraphNode("D"),
            };

            Assert.That(actual, Is.EquivalentTo(expeced));
        }


        private class GraphNode : IGraphNode
        {
            public string Value { get; set; }
            public IEnumerable<IGraphEdge> Connections { get; set; }

            public GraphNode(string value)
            {
                Value = value;
            }

            public override bool Equals(object? obj)
            {
                return obj is GraphNode node &&
                       Value == node.Value;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value);
            }
        }

        private class GraphEdge : IGraphEdge
        {
            public IGraphNode Target { get; set; }
            public GraphEdge(IGraphNode target)
            {
                Target = target;
            }
        }
    }
}
