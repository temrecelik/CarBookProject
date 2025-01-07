
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.ContactHandler
{
   public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public CreateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        
        public async Task Handle(CreateContactCommand command)
        {
            var Contact = new Contact
            {
              Email = command.Email,
              SendDatae = command.SendDatae,
              Message = command.Message,
              Name = command.Name,
              Phone = command.Phone,
             
            };
            
           

            await _ContactRepository.AddAsync(Contact);
        }
    }
}
