using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IAuditoriaRepository
    {
        Task<Auditoria> Create(AuditoriaDtos auditoria); // Cria novo registro
        Task<Auditoria> Update(string id, AuditoriaDtos auditoria); // Atualiza por ID
        Task<bool> DeleteById(string id); // Remove por ID
        Task<List<Auditoria>> GetAll(); // Retorna todos
        Task<Auditoria> GetById(string id); // Retorna um por ID
        Task<List<Auditoria>> GetByTabela(string nmTabela); // Filtro por tabela
        Task<List<Auditoria>> GetByOperacao(string dsOperacao); // Filtro por operação
        Task<List<Auditoria>> GetByUsuario(string idUsuario); // Filtro por usuário
        Task<List<Auditoria>> GetByPeriodo(DateTime dataInicio, DateTime dataFim); // Filtro por período
    }
}
