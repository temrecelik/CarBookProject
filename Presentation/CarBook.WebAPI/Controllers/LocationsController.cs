using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            /*her crud işlemi için bir request yazdık mediatR kullanırken direkt request classını send methodunda 
              parametre veririz*/
            var values = await _mediator.Send(new GetLocationQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(await _mediator.Send(new GetLocationByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)

        {
            await _mediator.Send(command);
            return Ok("Location eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location silindi");
        }
    }
}
