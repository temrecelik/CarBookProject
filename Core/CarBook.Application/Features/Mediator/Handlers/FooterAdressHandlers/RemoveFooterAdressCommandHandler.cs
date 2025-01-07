using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class RemoveFooterAdressCommandHandler : IRequestHandler<RemoveFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _footerAdressRepository;

        public RemoveFooterAdressCommandHandler(IRepository<FooterAddress> footerAdressRepository)
        {
            _footerAdressRepository = footerAdressRepository;
        }

        public async Task Handle(RemoveFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _footerAdressRepository.GetByIdsync(request.Id);

            _footerAdressRepository.Remove(entity); 
        }
    }
}
