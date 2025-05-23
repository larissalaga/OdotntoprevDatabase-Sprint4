using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly IMongoCollection<Auditoria> _auditoriaCollection;

        public AuditoriaRepository(MongoContext context)
        {
            _auditoriaCollection = context.Database.GetCollection<Auditoria>("AUDITORIA");
        }

        public async Task<Auditoria> Create(AuditoriaDtos dto)
        {
            var auditoria = new Auditoria
            {
                NmTabela = dto.nm_tabela,
                DsOperacao = dto.ds_operacao,
                DtOperacao = dto.dt_operacao == default ? DateTime.Now : dto.dt_operacao,
                IdUsuario = dto.id_usuario,
                NmValoresAnteriores = dto.nm_valores_anteriores
            };

            await _auditoriaCollection.InsertOneAsync(auditoria);
            return auditoria;
        }

        public async Task<bool> DeleteById(string id)
        {
            var objectId = ObjectId.Parse(id);
            var result = await _auditoriaCollection.DeleteOneAsync(a => a.IdAuditoria == objectId);
            return result.DeletedCount > 0;
        }

        public async Task<List<Auditoria>> GetAll()
        {
            return await _auditoriaCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Auditoria> GetById(string id)
        {
            var objectId = ObjectId.Parse(id);
            return await _auditoriaCollection.Find(a => a.IdAuditoria == objectId).FirstOrDefaultAsync();
        }

        public async Task<List<Auditoria>> GetByOperacao(string operacao)
        {
            return await _auditoriaCollection.Find(a => a.DsOperacao == operacao).ToListAsync();
        }

        public async Task<List<Auditoria>> GetByPeriodo(DateTime inicio, DateTime fim)
        {
            return await _auditoriaCollection.Find(a => a.DtOperacao >= inicio && a.DtOperacao <= fim).ToListAsync();
        }

        public async Task<List<Auditoria>> GetByTabela(string tabela)
        {
            return await _auditoriaCollection.Find(a => a.NmTabela == tabela).ToListAsync();
        }

        public async Task<List<Auditoria>> GetByUsuario(string usuario)
        {
            return await _auditoriaCollection.Find(a => a.IdUsuario == usuario).ToListAsync();
        }

        public async Task<Auditoria> Update(string id, AuditoriaDtos dto)
        {
            var objectId = ObjectId.Parse(id);
            var auditoria = await GetById(id);
            if (auditoria == null) throw new Exception("Auditoria não encontrada.");

            auditoria.NmTabela = !string.IsNullOrEmpty(dto.nm_tabela) ? dto.nm_tabela : auditoria.NmTabela;
            auditoria.DsOperacao = !string.IsNullOrEmpty(dto.ds_operacao) ? dto.ds_operacao : auditoria.DsOperacao;
            auditoria.IdUsuario = !string.IsNullOrEmpty(dto.id_usuario) ? dto.id_usuario : auditoria.IdUsuario;
            auditoria.NmValoresAnteriores = !string.IsNullOrEmpty(dto.nm_valores_anteriores) ? dto.nm_valores_anteriores : auditoria.NmValoresAnteriores;

            if (dto.dt_operacao != default)
                auditoria.DtOperacao = dto.dt_operacao;

            await _auditoriaCollection.ReplaceOneAsync(a => a.IdAuditoria == objectId, auditoria);
            return auditoria;
        }
    }
}
