namespace Dados.Cadastro
{
    public class Atendimento : Base
    {
        public string Descricao { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string PessoaId { get; set; }
        public string TipoAtendimentoId { get; set; }

        public virtual TipoAtendimento TipoAtendimento { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
