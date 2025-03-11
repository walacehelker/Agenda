namespace Dados.Cadastro
{
    public class TipoAtendimento : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual List<Atendimento> AtendimentoList { get; set; }
    }
}
