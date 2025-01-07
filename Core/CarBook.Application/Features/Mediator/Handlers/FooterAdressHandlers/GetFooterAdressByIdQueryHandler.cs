using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
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
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _footerAdressRepository;

        public GetFooterAdressByIdQueryHandler(IRepository<FooterAddress> footerAdressRepository)
        {
            _footerAdressRepository = footerAdressRepository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _footerAdressRepository.GetByIdsync(request.Id);

            return new GetFooterAdressByIdQueryResult
            {
                Address = entity.Address,
                Description = entity.Description,
                Email = entity.Email,
                FooterAddressId = entity.FooterAddressId,
                Phone = entity.Phone,
            };
        }
    }
}
