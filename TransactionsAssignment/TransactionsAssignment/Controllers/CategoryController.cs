using CsvHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Helper;
using TransactionsAssignment.Service.Features.CategoryFeatures.Commands;
using TransactionsAssignment.Service.Features.TransactionFeatures.Queries;

namespace TransactionsAssignment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Category")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file)
        {
            var requestedList = file.CSVToList<Category>();
            return Ok(await Mediator.Send(new CreateCategoryCommand() { RequestedList= (List<Category>)requestedList }));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTransactioQuery() ));
        }
    }
}
