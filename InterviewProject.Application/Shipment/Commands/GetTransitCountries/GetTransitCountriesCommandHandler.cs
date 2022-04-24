using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Application.Interfaces;
using InterviewProject.Domain.Exceptions;
using InterviewProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject.Application.Shipment.Commands.GetTransitCountries
{
    public class GetTransitCountriesCommandHandler : IRequestHandler<GetTransitCountriesRequest, GetTransitCountriesResponse>
    {
        private readonly IApplicationDbContext _context;
        public GetTransitCountriesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetTransitCountriesResponse> Handle(GetTransitCountriesRequest request, CancellationToken cancellationToken)
        {
            var startCountry = _context.Countries.SingleOrDefault(country => country.Code == "USA")
                ?? throw new EntityNotFoundException();

            var destinationCountry = _context.Countries.SingleOrDefault(country => country.Code == request.DestinationCode)
                ?? throw new EntityNotFoundException();

            var countries = await _context.Countries.Include(c => c.Borders).ToListAsync();

            
        }

        private void FindShortestPath(Country start, Country destination, List<Country> countries)
        {
            Queue<Country> queue = new Queue<Country>();

            Dictionary<Country, NodeStats> nodesStats = new Dictionary<Country, NodeStats>();

            countries.ForEach(country =>
            {
                nodesStats.Add(country, new NodeStats());
            });

            queue.Enqueue(start);

            nodesStats[start].Processed = true;

            nodesStats[start].Distance = 0;

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                current.Borders.ToList().ForEach(border =>
                {
                    var neighbour = border.Neighbour;
                    if (nodesStats[neighbour].Processed == false)
                    {
                        queue.Enqueue(neighbour);

                        nodesStats[neighbour].Processed = true;
                        nodesStats[neighbour].Distance = nodesStats[current].Distance + 1;
                        nodesStats[neighbour].Previous = current;
                    }
                });

            }
            
        }


        private class NodeStats
        {
            public Country Previous { get; set; }
            public int Distance { get; set; }
            public bool Processed { get; set; }

            public NodeStats()
            {
                Previous = null;
                Distance = Int32.MaxValue;
                Processed = false;
            }
        }

    }

    
}
