using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _locationRepository;
        
        public GetLocationQueryHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _locationRepository.GetAllAsync();

            return entities.Select(x => new GetLocationQueryResult {
                locationId = x.locationId,
                Name  = x.Name,
            }).ToList();
        }
    }
}
