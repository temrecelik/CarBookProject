using CarBook.Application.Features.Mediator.Commands.LocationCommands;
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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public UpdateLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _locationRepository.GetByIdsync(request.locationId);

            entity.Name = request.Name;

            _locationRepository.Update(entity);
        }
    }
}
