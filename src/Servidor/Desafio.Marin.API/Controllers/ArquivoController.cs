// Recebe requisições HTTP

using Desafio.Marin.Aplicacao.Comandos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Marin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArquivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessarArquivo(ProcessarArquivoCNABCommand command)
        {
            var resultado = await _mediator.Send(command);

            if (resultado.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { resultado.Error });
            }
        }
    }
}
