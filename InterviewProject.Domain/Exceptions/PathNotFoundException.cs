using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Exceptions
{
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException(string start, string destiation) : base($"Path beetween {start} and {destiation} cannot be found.")
        {

        }
    }
}
