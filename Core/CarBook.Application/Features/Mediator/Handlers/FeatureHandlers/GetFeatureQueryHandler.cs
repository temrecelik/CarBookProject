using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    /*
     * Query'ler leri yazarken IRequest interface'sini implemente ettikten sonra ilgili entity için handler'lar
      yazılırkende IRequestHandler interface'i implemente edilir ve önce query yani request ve daha sonra 
      result yani response geçilir. Direkt olark bu şekilde mediatR bize gerekli handler sınıfını oluşturur.
     */
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _featureRepository;

        public GetFeatureQueryHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var entities = await _featureRepository.GetAllAsync();

            return entities.Select(x => new GetFeatureQueryResult { 
                FeatureId = x.FeatureId,    
                Name = x.Name,
            
            }).ToList();


        }
    }
}
