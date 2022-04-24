using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Common
{
    public interface IGraphEdge
    {
        IGraphNode Target { get; }
    }
}
