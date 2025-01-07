using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.CategoryHandler
{
   public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GetCategoryQueryResult>> Handle()
        {
            var entities = await _categoryRepository.GetAllAsync();

            return entities.Select(x => new GetCategoryQueryResult
            {
                Name = x.Name,
                CategoryId = x.CategoryId,
            }
            );
        }
    }
}
