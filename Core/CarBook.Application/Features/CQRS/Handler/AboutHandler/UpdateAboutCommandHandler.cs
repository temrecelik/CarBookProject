using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.AboutHandler
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var entity = await _aboutRepository.GetByIdsync(command.AboutId);
            entity.Title = command.Title;
            entity.Description = command.Description;
            entity.ImageUrl = command.ImageUrl;

            _aboutRepository.Update(entity);
        }
    }
}
