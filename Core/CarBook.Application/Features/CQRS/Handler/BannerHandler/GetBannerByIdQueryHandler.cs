using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.BannerHandler
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<GetBannerQueryResult> Handle(GetBannerByIdQuery query)
        {
            var banner = await _bannerRepository.GetByIdsync(query.Id);

            return new GetBannerQueryResult
            {
                BannerId = banner.BannerId,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl,
                Title = banner.Title,
            };

        }
    }
}
