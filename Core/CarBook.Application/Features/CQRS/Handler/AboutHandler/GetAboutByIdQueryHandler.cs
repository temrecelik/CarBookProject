using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.AboutHandler
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _aboutRepository;
        public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<GetAboutByIdQueryResult> Handler(GetAboutByIdQuery query)
        {
            var values = await _aboutRepository.GetByIdsync(query.AboutId);
            
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
        }



    }
}
