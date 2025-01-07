
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.ContactHandler
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
            _ContactRepository = ContactRepository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var entity = await _ContactRepository.GetByIdsync(command.ContactId);
            entity.Phone = command.Phone;
            entity.Email = command.Email;
            entity.Message = command.Message;
            entity.SendDatae = command.SendDatae;
            entity.Name = command.Name;
            _ContactRepository.Update(entity);
        }
    }
}
