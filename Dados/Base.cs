namespace Dados
{
    public class Base
    {
        public string Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
