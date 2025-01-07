
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handler.CategoryHandler;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
            private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
            private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
            private readonly GetCategoryQueryHandler getCategoryQueryHandler;
            private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
            private readonly RemoveCategoryCommandHandler deleteCategoryCommandHandler;

            public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler deleteCategoryCommandHandler)
            {
                this.createCategoryCommandHandler = createCategoryCommandHandler;
                this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
                this.getCategoryQueryHandler = getCategoryQueryHandler;
                this.updateCategoryCommandHandler = updateCategoryCommandHandler;
                this.deleteCategoryCommandHandler = deleteCategoryCommandHandler;
            }

            [HttpGet]
            public async Task<IActionResult> CategoryList()
            {
                var result = await getCategoryQueryHandler.Handle();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetCategoryById(int id)
            {
                var result = await getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(id));
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
            {
                await createCategoryCommandHandler.Handle(command);
                return Ok("Kategori eklendi");
            }

            [HttpDelete]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                await deleteCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
                return Ok("Kategori silindi");
            }

            [HttpPut]
            public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
            {
                await updateCategoryCommandHandler.Handle(command);
                return Ok("Kategori güncellendi");
            }
        }
    }

