using CarBook.Application.Features.CQRS.Commands.AboutCommand;
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
    public class CreateCarCommandHandler
    {
        public IRepository<Car> _carRepository;

        public CreateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _carRepository.AddAsync(
                new Car
                {
                    BrandId = command.BrandId,
                    Seat = command.Seat,
                    BigImageUrl = command.BigImageUrl,
                    model = command.model,
                    CoverImageUrl = command.CoverImageUrl,
                    Luggage = command.Luggage,
                    Fuel = command.Fuel,
                    Km = command.Km,
                    Transmission = command.Transmission,
                    
                   
                }
                );
        }
    }
}
