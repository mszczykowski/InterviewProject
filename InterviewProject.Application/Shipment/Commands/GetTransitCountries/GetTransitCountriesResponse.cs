using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace InterviewProject.Application.Shipment.Commands.GetTransitCountries
{
    public class GetTransitCountriesResponse
    {
        [JsonPropertyName("destiation")]
        public string DestinationCode { get; set; }
        [JsonPropertyName("list")]
        public List<string> TransitCountries { get; set; }

        public GetTransitCountriesResponse()
        {
            TransitCountries = new List<string>();
        }
    }
}
