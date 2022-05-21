using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.SubCategoryCommands.CreateSubCategory;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCategoryController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-subcategory")]
        public async Task<IActionResult> CreateSubCategory([FromBody] CreateSubCategoryDto request)
        {
            var response = await _mediator.Send(new CreateSubCategoryCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}