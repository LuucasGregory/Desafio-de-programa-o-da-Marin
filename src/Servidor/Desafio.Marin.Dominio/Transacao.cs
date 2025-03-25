// regras do negocio 

namespace Desafio.Marin.Dominio
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public TipoTransacao Tipo { get; set; }
        public DateTimeOffset Data { get; set; }
        public decimal Valor { get; set; }
        public string Cpf { get; set; }
        public string Cartao { get; set; }
        public string Representante { get; set; }
        public string NomeLoja { get; set; }

        public Transacao(TipoTransacao tipo, DateTimeOffset data, decimal valor, string cpf, string cartao, string representante, string nomeLoja)
        {
            Tipo = tipo;
            Data = data;
            Valor = valor;
            Cpf = cpf;
            Cartao = cartao;
            Representante = representante;
            NomeLoja = nomeLoja;
        }
    }
}
