using ApiTarefas.Integration.Response;
using Refit;

namespace ApiTarefas.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
