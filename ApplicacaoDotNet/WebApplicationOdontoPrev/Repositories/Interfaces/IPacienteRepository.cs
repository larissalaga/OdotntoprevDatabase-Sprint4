using WebApplicationOdontoPrev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObterTodosAsync();
        Task<Paciente> ObterPorIdAsync(string id);
        Task<Paciente> ObterPorCpfAsync(string cpf);
        Task InserirAsync(Paciente paciente);
        Task AtualizarAsync(string id, Paciente pacienteAtualizado);
        Task RemoverAsync(string id);
    }
}
