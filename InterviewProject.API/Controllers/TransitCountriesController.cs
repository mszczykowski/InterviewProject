using Microsoft.AspNetCore.Mvc;
using InterviewProject.Application.Shipment.Commands.GetTransitCountries;
using MediatR;

namespace InterviewProject.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class TransitCountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TransitCountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("/{query?}")]
        public async Task<GetTransitCountriesResponse> GetTransitCountries(string? query)
        {
            var request = new GetTransitCountriesRequest(query);

            return await _mediator.Send(request);
        }
    }
}
