using Desafio.Marin.Aplicacao.Comandos;
using Desafio.Marin.Aplicacao.Modelos;
using Desafio.Marin.Aplicacao.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Marin.API.Controllers
{
    /// <summary>
    /// Controller para processamento de arquivos CNAB
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public TransacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Processa um arquivo CNAB que contém transações
        /// </summary>
        /// <param name="command">Arquivo CNAB</param>
        /// <param name="cancellationToken"></param>
        [HttpPost("cnab")]
        public async Task<IActionResult> ProcessarArquivo(ProcessarArquivoCNABCommand command, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(command, cancellationToken);

            if (resultado.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { resultado.Error });
            }
        }

        /// <summary>
        /// Obtém todas as transações
        /// </summary>
        /// <returns>Retorna todas as transações cadastradas</returns>
        /// <response code="200">Uma lista de transações</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransacaoModelo>))]
        public async Task<IActionResult> BuscarTransacoes(CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new BuscarTransacoesQuery(), cancellationToken);

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Value);
            }
            else
            {
                return BadRequest(new { resultado.Error });
            }
        }
    }
}
