using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _footerAdressRepository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAddress> footerAdressRepository)
        {
            _footerAdressRepository = footerAdressRepository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _footerAdressRepository.GetByIdsync(request.FooterAddressId);

            entity.Description = request.Description;
            entity.Address = request.Address;
            entity.Email = request.Email;
            entity.Phone = request.Phone;

            _footerAdressRepository.Update(entity); 
        }
    }
}
