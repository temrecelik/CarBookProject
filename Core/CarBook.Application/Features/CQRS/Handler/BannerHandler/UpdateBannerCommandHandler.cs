using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handler.BannerHandler
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(UpdateBannerCommand request)
        {
            
            var banner = await _bannerRepository.GetByIdsync(request.BannerId);

            banner.Title = request.Title;
            banner.Description = request.Description;
            banner.VideoDescription = request.VideoDescription;
            banner.VideoUrl = request.VideoUrl;

            _bannerRepository.Update(banner);


        }
    }
}
