using GestaoOcorrencias.WebApi.Entities;

namespace GestaoOcorrencias.WebApi.Services;

public interface IOcorrenciaService
{
    Task Create(Ocorrencia ocorrencia);
    Task<IEnumerable<Ocorrencia>> Get();
    Task<Ocorrencia> Get(int id);
    Task Update(int id, Ocorrencia ocorrencia);
    Task Delete(int id);
}

