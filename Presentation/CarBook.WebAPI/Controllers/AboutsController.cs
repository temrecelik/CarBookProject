using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Features.CQRS.Handler.AboutHandler;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler deleteAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler deleteAboutCommandHandler)
        {
            this.createAboutCommandHandler = createAboutCommandHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.getAboutQueryHandler = getAboutQueryHandler;
            this.updateAboutCommandHandler = updateAboutCommandHandler;
            this.deleteAboutCommandHandler = deleteAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var result = await getAboutQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var result = await getAboutByIdQueryHandler.Handler(new GetAboutByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout( CreateAboutCommand command)
        {
            await createAboutCommandHandler.Handle(command);
            return Ok("Hakkında Bilgisi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await deleteAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkında Bilgisi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await updateAboutCommandHandler.Handle(command);
            return Ok("Hakkında Bilgisi güncellendi");
        }

    }
}
