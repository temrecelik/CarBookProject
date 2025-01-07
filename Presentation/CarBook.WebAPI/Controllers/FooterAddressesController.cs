

using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            /*her crud işlemi için bir request yazdık mediatR kullanırken direkt request classını send methodunda 
              parametre veririz*/
            var values = await _mediator.Send(new GetFooterAdressQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdressById(int id)
        {
            return Ok(await _mediator.Send(new GetFooterAdressByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressCommand command)

        {
            await _mediator.Send(command);
            return Ok("FooterAdress eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAdress güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("FooterAdress silindi");
        }
    }
}
