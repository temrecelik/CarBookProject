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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        public IRepository<Location> _locationRepository;

        public GetLocationByIdQueryHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity =await _locationRepository.GetByIdsync(request.Id);

            return new GetLocationByIdQueryResult {
            locationId = entity.locationId,
            Name = entity.Name,
            
            };
        }
    }
}
