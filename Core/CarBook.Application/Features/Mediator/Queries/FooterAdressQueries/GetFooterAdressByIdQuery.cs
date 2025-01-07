using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressByIdQuery : IRequest<GetFooterAdressByIdQueryResult>
    {
        public GetFooterAdressByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; } 
    }
}

