using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.CarHandler
{
    public class GetCarQueryByIdHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarQueryByIdHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
   

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var entity = await _carRepository.GetByIdsync(query.Id);

            return new GetCarByIdQueryResult
            {
                CarId = entity.CarId,
                BrandId = entity.BrandId,
                Seat = entity.Seat,
                BigImageUrl = entity.BigImageUrl,
                CoverImageUrl = entity.CoverImageUrl,
                Transmission = entity.Transmission,
                model = entity.model,
                Km =entity.Km,
                Luggage =entity.Luggage,
                Fuel = entity.Fuel,
            };
    }

    }
}
