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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _CarRepository;

        public UpdateCarCommandHandler(IRepository<Car> carRepository)
        {
            _CarRepository = carRepository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var entity = await _CarRepository.GetByIdsync(command.CarId);

          
            entity.Fuel = command.Fuel;
            entity.Transmission = command.Transmission;
            entity.BigImageUrl = command.BigImageUrl;
            entity.BrandId = command.BrandId;
            entity.CoverImageUrl = command.CoverImageUrl;
            entity.Km = command.Km;
            entity.Seat = command.Seat;
            entity.Luggage = command.Luggage;
            entity.model = command.model;
            entity.Fuel = command.Fuel;

            _CarRepository.Update(entity);
        }

    }
}
