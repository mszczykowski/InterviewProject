using InterviewProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Entities
{
    public class Country : IGraphNode
    {
        [Key]
        [Required]
        public String Code { get; set; }
        public String Name { get; set; }

        public virtual IEnumerable<Border> Borders { get; set; }


        [NotMapped]
        public string Value => Code;
        [NotMapped]
        public IEnumerable<IGraphEdge> Connections => Borders;
    }
}
