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
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public GetBannerQueryHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IEnumerable<GetBannerQueryResult>> Handle()
        {
            var entities = await _bannerRepository.GetAllAsync();

            return
                entities.Select(x => new GetBannerQueryResult
                {
                    BannerId = x.BannerId,
                    Title = x.Title,
                    Description = x.Description,
                    VideoDescription = x.VideoDescription,
                    VideoUrl = x.VideoUrl
                }).ToList();
                
        }
    }
}
