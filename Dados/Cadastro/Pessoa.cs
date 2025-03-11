namespace Dados.Cadastro
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Crm { get; set; }
        public string Cnpj { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }

        public virtual List<Atendimento> AtendimentoList { get; set; }
        public virtual UsuarioLogin UsuarioLogin { get; set; }
    }
}
