using Desafio.Marin.Aplicacao.Comandos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Marin.API.Controllers
{
    /// <summary>
    /// Controller para processamento de arquivos CNAB
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArquivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Processa um arquivo CNAB
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
