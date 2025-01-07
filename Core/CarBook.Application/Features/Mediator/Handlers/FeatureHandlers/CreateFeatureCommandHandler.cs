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
{/*
  * MediatR'de response olmadığı için hanler class'ları yazılırken sadece request sınıfını IRequestHandler 
    interface'sine veririz.
  */
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        public IRepository<Feature> _featureRepository;

        public CreateFeatureCommandHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _featureRepository.AddAsync(new Feature
            {
                Name = request.Name,
            });



        }
    }
}
