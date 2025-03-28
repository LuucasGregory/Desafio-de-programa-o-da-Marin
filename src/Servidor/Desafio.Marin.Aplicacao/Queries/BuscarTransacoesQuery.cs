using AutoMapper;
using CSharpFunctionalExtensions;
using Desafio.Marin.Aplicacao.Modelos;
using Desafio.Marin.Dominio;
using MediatR;

namespace Desafio.Marin.Aplicacao.Queries
{
    /// <summary>
    /// Query para buscar todas as transações
    /// </summary>
    public class BuscarTransacoesQuery : IRequest<Result<List<TransacaoModelo>>>
    { }

    public class BuscarTransacoesQueryHandler : IRequestHandler<BuscarTransacoesQuery, Result<List<TransacaoModelo>>>
    {
        private readonly IMapper _mapper;
        private readonly ITransacaoRepository _transacaoRepository;

        public BuscarTransacoesQueryHandler(IMapper mapper, ITransacaoRepository transacaoRepository)
        {
            _mapper = mapper;
            _transacaoRepository = transacaoRepository;
        }

        public async Task<Result<List<TransacaoModelo>>> Handle(BuscarTransacoesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TransacaoModelo>>(await _transacaoRepository.BuscarTodosAsync(cancellationToken));
        }
    }
}
