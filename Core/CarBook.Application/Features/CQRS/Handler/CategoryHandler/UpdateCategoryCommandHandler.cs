
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
    public class UpdateCategoryCommandHandler
    {

        private readonly IRepository<Category> _CategoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var entity = await _CategoryRepository.GetByIdsync(command.CategoryId);
            
    
            entity.Name = command.Name;

            _CategoryRepository.Update(entity);
        }
    }
}
