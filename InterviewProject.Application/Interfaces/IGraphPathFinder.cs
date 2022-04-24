using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Domain.Common;

namespace InterviewProject.Application.Interfaces
{
    public interface IGraphPathFinder
    {
        List<IGraphNode> FindShortestPath(IGraphNode start, IGraphNode target, List<IGraphNode> nodes);
    }
}
