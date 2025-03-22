using CSharpFunctionalExtensions;
using Desafio.Marin.Dominio;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Desafio.Marin.Aplicacao.Comandos
{
    public class ProcessarArquivoCNABCommand : IRequest<Result>
    {
        public IFormFile Arquivo { get; set; }
    }

    public class ProcessarArquivoCNABCommandHandler : IRequestHandler<ProcessarArquivoCNABCommand, Result>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessarArquivoCNABCommandHandler(ITransacaoRepository transacaoRepository, IUnitOfWork unitOfWork)
        {
            _transacaoRepository = transacaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ProcessarArquivoCNABCommand request, CancellationToken cancellationToken)
        {
            if (Path.GetExtension(request.Arquivo.FileName) != "cnab")
            {
                return Result.Failure("Arquivo no formato incorreto");
            }

            // Ler arquivo, pegar de cada tamanho a propriedade para instanciar o ArquivoCNAB

            // Inserir no banco de dados
            await _transacaoRepository.InserirAsync(new Transacao(TipoTransacao.Debito, DateTimeOffset.Now, 10.0m, "1", "2", "Fulano", "Ciclano"));

            await _unitOfWork.CommitAsync();

            // Retornar valor
            return Result.Success();
        }
    }
}
