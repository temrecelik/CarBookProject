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
    public class RemoveBannerCommandHandler
    {
        public readonly IRepository<Banner> _bannerRepository;

        public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var entity = await _bannerRepository.GetByIdsync(command.Id);
            _bannerRepository.Remove(entity);
        }
    }
}
