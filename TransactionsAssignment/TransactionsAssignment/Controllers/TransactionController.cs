using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TransactionsAssignment.Service.Features.TransactionFeatures.Commands;
using TransactionsAssignment.Service.Features.TransactionFeatures.Queries;

namespace TransactionsAssignment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Transaction")]
    [ApiVersion("1.0")]
    public class TransactionController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll(string kind)
        {
            return Ok(await Mediator.Send(new GetAllTransactioQuery { Kind = kind }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetTransactioByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTransactioByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTransactioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
