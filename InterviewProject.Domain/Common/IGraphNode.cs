using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Common
{
    public interface IGraphNode
    {
        string Value { get; }
        IEnumerable<IGraphEdge> Connections { get; }
    }
}
