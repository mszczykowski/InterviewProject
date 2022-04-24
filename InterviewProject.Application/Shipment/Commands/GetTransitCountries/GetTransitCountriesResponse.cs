using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InterviewProject.Application.Shipment.Commands.GetTransitCountries
{
    public class GetTransitCountriesResponse
    {
        public string DestinationCode { get; set; }
        public List<string> TransitCountries { get; set; }
    }
}
