using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetAllCategories;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _mediator.Send(new GetAllCategoriesQuery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}