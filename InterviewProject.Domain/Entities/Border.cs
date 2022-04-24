using InterviewProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Entities
{
    public class Border : IGraphEdge
    {
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public string NeighbourId { get; set; }
        public Country Neighbour { get; set; }


        [NotMapped]
        public IGraphNode Target => Neighbour;
    }
}
