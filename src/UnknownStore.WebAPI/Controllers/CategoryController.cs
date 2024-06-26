﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnknownStore.BusinessLogic.CQRS.Commands.CategoryCommands.CreateCategory;
using UnknownStore.BusinessLogic.CQRS.Queries.CategoryQueries.GetFullInfoAllCategories;
using UnknownStore.Common.DataTransferObjects.Create;

namespace UnknownStore.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("store/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetFullInfoAllCategories()
        {
            var response = await _mediator.Send(new GetAllFullInfoCategoriesQuery());
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("add-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            var response = await _mediator.Send(new CreateCategoryCommand(request));
            return StatusCode((int)response.StatusCode, response);
        }
    }
}