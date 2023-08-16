using ApiTarefas.Integration.Response;

namespace ApiTarefas.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
