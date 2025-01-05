using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.CarHandler
{
    public  class RemoveCarCommandHandler
    {
        public readonly IRepository<Car> _carRepository;

        public RemoveCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var entity = await _carRepository.GetByIdsync(command.Id);
            _carRepository.Remove(entity);
        }
    }
}
