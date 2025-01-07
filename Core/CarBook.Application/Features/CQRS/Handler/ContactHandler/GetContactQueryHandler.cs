using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.ContactHandler
{
    public  class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _ContactRepository;

        public GetContactQueryHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task<IEnumerable<GetContactQueryResult>> Handle()
        {

            var values = await _ContactRepository.GetAllAsync();

            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                SendDatae = x.SendDatae,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
