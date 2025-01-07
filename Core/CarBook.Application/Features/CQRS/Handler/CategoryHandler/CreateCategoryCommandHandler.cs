
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.CategoryHandler
{
   public class CreateCategoryCommandHandler
    {

        private readonly IRepository<Category> _CategoryRepository;

        public CreateCategoryCommandHandler(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var Category = new Category
            {
                Name =command.Name
            };

            await _CategoryRepository.AddAsync(Category);
        }
    }
}
