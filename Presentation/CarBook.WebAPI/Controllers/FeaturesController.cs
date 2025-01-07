using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            /*her crud işlemi için bir request yazdık mediatR kullanırken direkt request classını send methodunda 
              parametre veririz*/
            var values = await _mediator.Send(new GetFeatureQuery());

            return Ok(values);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            return Ok(await _mediator.Send(new GetFeatureByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)

        {
            await _mediator.Send(command);
            return Ok("Araba özelliği eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba özelliği güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Araba Özelliği silindi");
        }
    }
}
