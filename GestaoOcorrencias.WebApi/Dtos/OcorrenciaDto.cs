namespace GestaoOcorrencias.WebApi.Dtos
{
    public class OcorrenciaDto
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelAberturaId { get; set; }
        public string Conclusao { get; set; }
        public int ResponsavelOcorrenciaId { get; set; }
    }
}
