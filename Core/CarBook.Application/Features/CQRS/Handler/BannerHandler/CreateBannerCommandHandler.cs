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
    public class CreateBannerCommandHandler
    {
        public readonly IRepository<Banner> _bannerRepository;

        public CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(CreateBannerCommand request)
        {
            var banner = new Banner
            {
                Title = request.Title,
                Description = request.Description,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl
            };

            await _bannerRepository.AddAsync(banner);
        }
    }
}
