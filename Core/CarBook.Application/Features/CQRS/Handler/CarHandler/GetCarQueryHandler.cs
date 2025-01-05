using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Features.CQRS.Handler.CarHandler
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarQueryHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<GetCarQueryResult>> Handle()
        {
            var entities = await _carRepository.GetAllAsync();

            return entities.Select(x => new GetCarQueryResult
            {
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmission = x.Transmission,
                model = x.model
            }
            ).ToList();

        }
    }
}
