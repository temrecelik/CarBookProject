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
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public GetFooterAdressQueryHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var entities = await _footerAddressRepository.GetAllAsync();

            return entities.Select(x => new GetFooterAdressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressId = x.FooterAddressId,
                 Phone = x.Phone,
            }).ToList();
        }
    }
}
