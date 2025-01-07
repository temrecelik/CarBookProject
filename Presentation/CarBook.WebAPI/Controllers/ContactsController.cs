using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handler.ContactHandler;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler createContactCommandHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;
        private readonly RemoveContactCommandHandler deleteContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler deleteContactCommandHandler)
        {
            this.createContactCommandHandler = createContactCommandHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.getContactQueryHandler = getContactQueryHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
            this.deleteContactCommandHandler = deleteContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var result = await getContactQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await getContactByIdQueryHandler.Handler(new GetContactByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok("İletişim bilgileri eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await deleteContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim bilgileri  silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("İletişim bilgileri  güncellendi");
        }
    }
}
