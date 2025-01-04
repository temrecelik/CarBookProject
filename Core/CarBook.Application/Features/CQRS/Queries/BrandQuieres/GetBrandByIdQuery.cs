using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BrandQuieres
{
    public class GetBrandByIdQuery
    {
        public GetBrandByIdQuery(int Id)
        {
            BrandId = Id;
        }

        public int BrandId { get; set; }

    }
}
