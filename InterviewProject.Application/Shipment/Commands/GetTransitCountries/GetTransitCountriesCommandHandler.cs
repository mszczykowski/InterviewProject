using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Application.Interfaces;
using InterviewProject.Domain.Exceptions;
using InterviewProject.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using InterviewProject.Domain.Entities;

namespace InterviewProject.Application.Shipment.Commands.GetTransitCountries
{
    public class GetTransitCountriesCommandHandler : IRequestHandler<GetTransitCountriesRequest, GetTransitCountriesResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGraphPathFinder _graphPathFinder;

        private readonly string startCode = "USA";


        public GetTransitCountriesCommandHandler(IApplicationDbContext context, IGraphPathFinder graphPathFinder)
        {
            _context = context;
            _graphPathFinder = graphPathFinder;
        }

        public async Task<GetTransitCountriesResponse> Handle(GetTransitCountriesRequest request, CancellationToken cancellationToken)
        {
            var startCountry = _context.Countries.SingleOrDefault(country => country.Code == startCode)
                ?? throw new EntityNotFoundException(startCode, nameof(Country));

            var destinationCountry = _context.Countries.SingleOrDefault(country => country.Code == request.DestinationCode)
                ?? throw new EntityNotFoundException(request.DestinationCode, nameof(Country));

            var countries = await _context.Countries.Include(c => c.Borders).Cast<IGraphNode>().ToListAsync();

            var path = _graphPathFinder.FindShortestPath(startCountry, destinationCountry, countries );

            var response = new GetTransitCountriesResponse();
            response.DestinationCode = destinationCountry.Code;
            path.ForEach(country =>
            {
                response.TransitCountries.Add(country.Value);
            });

            return response;
        }
    }
}
