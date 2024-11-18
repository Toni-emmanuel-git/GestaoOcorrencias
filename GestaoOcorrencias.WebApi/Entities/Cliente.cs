namespace GestaoOcorrencias.WebApi.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
    }
}
