using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class DentistaRepository : IDentistaRepository
    {
        private readonly IMongoCollection<Dentista> _dentistas;

        public DentistaRepository(MongoContext context)
        {
            _dentistas = context.Dentistas;
        }

        public async Task<List<Dentista>> ObterTodosAsync()
        {
            return await _dentistas.Find(d => true).ToListAsync();
        }

        public async Task<Dentista> ObterPorIdAsync(string id)
        {
            return await _dentistas.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Dentista> ObterPorDocumentoAsync(string docIdentificacao)
        {
            return await _dentistas.Find(d => d.ds_doc_identificacao == docIdentificacao).FirstOrDefaultAsync();
        }

        public async Task InserirAsync(Dentista dentista)
        {
            await _dentistas.InsertOneAsync(dentista);
        }

        public async Task AtualizarAsync(string id, Dentista dentistaAtualizado)
        {
            await _dentistas.ReplaceOneAsync(d => d.Id == id, dentistaAtualizado);
        }

        public async Task RemoverAsync(string id)
        {
            await _dentistas.DeleteOneAsync(d => d.Id == id);
        }
    }
}
