using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IMongoCollection<Paciente> _pacientes;

        public PacienteRepository(MongoContext context)
        {
            _pacientes = context.Pacientes;
        }

        public async Task<List<Paciente>> ObterTodosAsync()
        {
            return await _pacientes.Find(p => true).ToListAsync();
        }

        public async Task<Paciente> ObterPorIdAsync(string id)
        {
            return await _pacientes.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Paciente> ObterPorCpfAsync(string cpf)
        {
            return await _pacientes.Find(p => p.nr_cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task InserirAsync(Paciente paciente)
        {
            await _pacientes.InsertOneAsync(paciente);
        }

        public async Task AtualizarAsync(string id, Paciente pacienteAtualizado)
        {
            await _pacientes.ReplaceOneAsync(p => p.Id == id, pacienteAtualizado);
        }

        public async Task RemoverAsync(string id)
        {
            await _pacientes.DeleteOneAsync(p => p.Id == id);
        }
    }
}
