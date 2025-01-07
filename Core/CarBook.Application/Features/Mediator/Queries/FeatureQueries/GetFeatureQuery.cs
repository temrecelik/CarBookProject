using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    /*
     MediatR ile query'ler yani request'leri IRequest sınıfı iler belirleriz ve response  olarak da  döneceği
     değeri geçeriz. Normalde GetFeatureQuery yoktur get işlemi ile geriye sadece bir response döner yani
     result döner ancak MediatR kullandığımızda her Crud işlemi için bir Query ya da command yani request sınıfı
     hazırlamak gereklidir.
     */
    public class GetFeatureQuery :IRequest<List<GetFeatureQueryResult>>
    {
    }
}
