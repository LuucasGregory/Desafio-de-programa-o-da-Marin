using AutoMapper;
using Desafio.Marin.Dominio;

namespace Desafio.Marin.Aplicacao.Modelos
{
    public class TransacaoModelo
    {
        public string? Tipo { get; set; }
        public DateTimeOffset? Data { get; set; }
        public decimal? Valor { get; set; }
        public string? Cpf { get; set; }
        public string? Cartao { get; set; }
        public string? Representante { get; set; }
        public string? NomeLoja { get; set; }
    }

    public class TransacaoModeloMappingProfile : Profile
    {
        public TransacaoModeloMappingProfile()
        {
            CreateMap<Transacao, TransacaoModelo>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Cartao, opt => opt.MapFrom(src => src.Cartao))
                .ForMember(dest => dest.Representante, opt => opt.MapFrom(src => src.Representante))
                .ForMember(dest => dest.NomeLoja, opt => opt.MapFrom(src => src.NomeLoja));
        }
    }
}
