namespace Desafio.Marin.Dominio
{
    public class ArquivoCNAB
    {
        public TipoTransacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public string Representante { get; set; }
        public string NomeLoja { get; set; }

        public ArquivoCNAB(TipoTransacao tipo, DateTime data, decimal valor, string cpf, string cartao, string representante, string nomeLoja)
        {
            Tipo = tipo;
            Data = data;
            Valor = valor;
            CPF = cpf;
            Cartao = cartao;
            Representante = representante;
            NomeLoja = nomeLoja;
        }
    }
}
