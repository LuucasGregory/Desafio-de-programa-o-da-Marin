using System.Globalization;
using System.Text;
using CSharpFunctionalExtensions;
using Desafio.Marin.Dominio;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Desafio.Marin.Aplicacao.Comandos
{
    /// <summary>
    /// Comando para processar um arquivo CNAB
    /// </summary>
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
            if (Path.GetExtension(request.Arquivo.FileName) != ".cnab")
            {
                return Result.Failure("Arquivo no formato incorreto");
            }

            // Ler arquivo, pegar de cada tamanho a propriedade para instanciar o ArquivoCNAB
            var transacoes = new List<Transacao>();

            using (var reader = new StreamReader(request.Arquivo.OpenReadStream(), Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var linha = await reader.ReadLineAsync();

                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    var transacao = new Transacao(
                        tipo: (TipoTransacao)int.Parse(linha.Substring(0, 1)),
                        data: DateTime.ParseExact(linha.Substring(1, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                        valor: decimal.Parse(linha.Substring(9, 10)) / 100,
                        cpf: linha.Substring(19, 11),
                        cartao: linha.Substring(30, 12),
                        representante: linha.Substring(48, 14).Trim(),
                        nomeLoja: linha.Substring(62, 18).Trim()
                    );

                    transacao.AtribuirHorario(TimeSpan.ParseExact(linha.Substring(42, 6), "hhmmss", CultureInfo.InvariantCulture));

                    transacoes.Add(transacao);
                }
            }

            // Inserir no banco de dados
            await _transacaoRepository.InserirAsync(transacoes, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            // Retornar valor
            return Result.Success();
        }
    }
}
