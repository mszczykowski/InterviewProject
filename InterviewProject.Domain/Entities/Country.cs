using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domain.Entities
{
    public class Country
    {
        [Key]
        public String Code { get; set; }
        public String Name { get; set; }

        public virtual IEnumerable<Border> Borders { get; set; }
    }
}
