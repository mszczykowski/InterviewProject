using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Application.Shipment.Commands.GetTransitCountries
{
    public class GetTransitCountriesRequest : IRequest<GetTransitCountriesResponse>
    {
        public string DestinationCode { get; set; }

        public GetTransitCountriesRequest(string destinationCode)
        {
            DestinationCode = destinationCode;
        }
    }
}
