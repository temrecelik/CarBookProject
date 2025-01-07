using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    internal class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        public IRepository<FooterAddress> _footerAdressRepository;

        public CreateFooterAdressCommandHandler(IRepository<FooterAddress> footerAdressRepository)
        {
            _footerAdressRepository = footerAdressRepository;
        }

        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            await _footerAdressRepository.AddAsync(
                new FooterAddress
                {
                    Address = request.Address,
                    Description = request.Description,
                    Email = request.Email,
                    Phone = request.Phone,
                    
                });
        }
    }
}
