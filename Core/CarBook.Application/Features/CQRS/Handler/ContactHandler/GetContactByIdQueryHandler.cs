using CarBook.Application.Features.CQRS.Queries.ContactQueries;
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
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _ContactRepository;
        public GetContactByIdQueryHandler(IRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task<GetContactByIdQueryResult> Handler(GetContactByIdQuery query)
        {
            var values = await _ContactRepository.GetByIdsync(query.Id);

            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                SendDatae = values.SendDatae,
                Email = values.Email,
                Message = values.Message,
                Name = values.Name,
                Phone = values.Phone,
            };
        }
    }
}
