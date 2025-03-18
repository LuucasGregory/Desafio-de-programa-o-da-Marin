using CSharpFunctionalExtensions;
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
        public ProcessarArquivoCNABCommandHandler()
        {
        }

        public Task<Result> Handle(ProcessarArquivoCNABCommand request, CancellationToken cancellationToken)
        {
            if (Path.GetExtension(request.Arquivo.FileName) != "cnab")
            {
                return Task.FromResult(Result.Failure("Arquivo no formato incorreto"));
            }

            // Ler arquivo, pegar de cada tamanho a propriedade para instanciar o ArquivoCNAB

            // Inserir no banco de dados

            // Retornar valor

            return Task.FromResult(Result.Success());
        }
    }
}
