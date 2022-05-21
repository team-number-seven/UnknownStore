using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.BrandCommands.CreateBrand;
using UnknownStore.BusinessLogic.CQRS.Queries.BrandQueries.GetAllBrands;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new GetAllBrandsQuery());
            return StatusCode((int)response.StatusCode, response);
        }


        [HttpPost]
        [Route("add-brand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto request)
        {
            var response = await _mediator.Send(new CreateBrandCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}