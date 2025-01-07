using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    /*
     cancellationToken sayfalarda yapılan işlemlerin ya da sayfaların yüklenememi  yada bu yüklenme işleminin uzun  sürmesi
     durumunda yapılan işlemi iptal edebilmek için kullanılan bir tokendır. İptal etme sinyali gönderir.
     */
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _featureRepository;

        public UpdateFeatureCommandHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }


        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _featureRepository.GetByIdsync(request.FeatureId);

            entity.Name = request.Name;

           _featureRepository.Update(entity);
        }
    }
}
