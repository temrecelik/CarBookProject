using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.CarHandler
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public  IEnumerable<GetCarWithBrandQuery> Handle()
        {
            var entities =  _carRepository.GetCarListWithBrand();
            
            

            return entities.Select( x => new GetCarWithBrandQuery
            {
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                BrandName =x.Brand.Name,
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
