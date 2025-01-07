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
    public class RemoveAboutCommandHandler
    {


        public readonly IRepository<About> _aboutRepository;

        public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }



        public async Task Handle(RemoveAboutCommand command)
        {
            var entity = await _aboutRepository.GetByIdsync(command.Id);
            _aboutRepository.Remove(entity);

        }
    }
}
