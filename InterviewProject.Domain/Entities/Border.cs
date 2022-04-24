using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Entities
{
    public class Border
    {
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public string NeighbourId { get; set; }
        public Country Neighbour { get; set; }
    }
}
