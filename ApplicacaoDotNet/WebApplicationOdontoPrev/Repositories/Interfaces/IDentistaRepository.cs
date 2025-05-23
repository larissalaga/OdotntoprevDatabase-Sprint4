using WebApplicationOdontoPrev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IDentistaRepository
    {
        Task<List<Dentista>> ObterTodosAsync();
        Task<Dentista> ObterPorIdAsync(string id);
        Task<Dentista> ObterPorDocumentoAsync(string docIdentificacao);
        Task InserirAsync(Dentista dentista);
        Task AtualizarAsync(string id, Dentista dentistaAtualizado);
        Task RemoverAsync(string id);
    }
}
