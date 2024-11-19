using GestaoOcorrencias.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.WebApi.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly GestaoOcorrenciasDbContext gestaoOcorrenciasDbContext;
        private DbSet<Ocorrencia> Ocorrencias => gestaoOcorrenciasDbContext.Ocorrencias;

        public OcorrenciaService(GestaoOcorrenciasDbContext gestaoOcorrenciasDbContext)
        {
            this.gestaoOcorrenciasDbContext = gestaoOcorrenciasDbContext;
        }
        public async Task Create(Ocorrencia ocorrencia)
        {
            await Ocorrencias.AddAsync(ocorrencia);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ocorrencia>> Get()
        {
            return await Ocorrencias.ToListAsync();
        }

        public async Task<Ocorrencia> Get(int id)
        {
            return await Ocorrencias.FirstOrDefaultAsync(ocorrencia => ocorrencia.Id == id);
        }

        public async Task Update(int id, Ocorrencia ocorrencia)
        {
            var existingOcorrencia = await Get(id);

            if (existingOcorrencia != null)
            {
                existingOcorrencia.DataAbertura = ocorrencia.DataAbertura;
                existingOcorrencia.DataOcorrencia = ocorrencia.DataOcorrencia;
                existingOcorrencia.Descricao = ocorrencia.Descricao;
                existingOcorrencia.ResponsavelAberturaId = ocorrencia.ResponsavelAberturaId;
                existingOcorrencia.Conclusao = ocorrencia.Conclusao;
                existingOcorrencia.ResponsavelOcorrenciaId = ocorrencia.ResponsavelOcorrenciaId;
            }
            Ocorrencias.Update(existingOcorrencia);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ocorrencia = await Get(id);
            Ocorrencias.Remove(ocorrencia);
            await gestaoOcorrenciasDbContext.SaveChangesAsync();
        }

    }
}
