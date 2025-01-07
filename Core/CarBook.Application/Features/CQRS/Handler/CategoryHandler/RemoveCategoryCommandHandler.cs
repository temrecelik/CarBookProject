using CarBook.Application.Features.CQRS.Commands.AboutCommand;
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
    public class RemoveCategoryCommandHandler
    {
        public readonly IRepository<Category> _categoryRepository;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        public async Task Handle(RemoveCategoryCommand command)
        {
            var entity = await _categoryRepository.GetByIdsync(command.Id);
            _categoryRepository.Remove(entity);
        }
    }
}
