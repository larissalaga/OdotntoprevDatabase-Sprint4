using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class RelatoriosRepository : IRelatoriosRepository
    {
        private readonly IMongoCollection<BsonDocument> _pacientes;

        public RelatoriosRepository(MongoContext context)
        {
            _pacientes = context.Database.GetCollection<BsonDocument>("PACIENTES");
        }

        public async Task<List<PerguntaReportDtos>> GetHistoricoRespostas(string cpf)
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument("nr_cpf", cpf)),
                new BsonDocument("$unwind", "$CHECK_IN"),
                new BsonDocument("$project", new BsonDocument
                {
                    { "Nome", "$nm_paciente" },
                    { "CPF", "$nr_cpf" },
                    { "Pergunta", "$CHECK_IN.pergunta" },
                    { "Resposta", "$CHECK_IN.resposta" },
                    { "Data", "$CHECK_IN.data" },
                    { "TotalPontos", new BsonInt32(0) }
                })
            };

            var result = await _pacientes.Aggregate<BsonDocument>(pipeline).ToListAsync();
            var output = new List<PerguntaReportDtos>();

            foreach (var doc in result)
            {
                output.Add(new PerguntaReportDtos
                {
                    Nome = doc.GetValue("Nome", "").AsString,
                    CPF = doc.GetValue("CPF", "").AsString,
                    Pergunta = doc.GetValue("Pergunta", "").AsString,
                    Resposta = doc.GetValue("Resposta", "").AsString,
                    Data = doc.GetValue("Data", BsonNull.Value).ToUniversalTime(),
                    TotalPontos = doc.GetValue("TotalPontos", 0).ToInt32()
                });
            }

            return output;
        }

        public async Task<List<RaioXAnalisesReportViewModel.RaioXAnalise>> GetRaioXAnalises(string cpf)
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument("nr_cpf", cpf)),
                new BsonDocument("$unwind", "$RAIO_X"),
                new BsonDocument("$match", new BsonDocument("RAIO_X.analise", new BsonDocument("$ne", BsonNull.Value))),
                new BsonDocument("$project", new BsonDocument
                {
                    { "nm_paciente", "$nm_paciente" },
                    { "nr_cpf", "$nr_cpf" },
                    { "dt_data_raio_x", "$RAIO_X.dt_data_raio_x" },
                    { "ds_raio_x", "$RAIO_X.ds_raio_x" },
                    { "dt_analise_raio_x", "$RAIO_X.analise.dt_analise_raio_x" },
                    { "ds_analise_raio_x", "$RAIO_X.analise.ds_analise_raio_x" },
                    { "nm_plano", "$PLANO.nm_plano" }
                })
            };

            var result = await _pacientes.Aggregate<BsonDocument>(pipeline).ToListAsync();
            var output = new List<RaioXAnalisesReportViewModel.RaioXAnalise>();

            foreach (var doc in result)
            {
                output.Add(new RaioXAnalisesReportViewModel.RaioXAnalise
                {
                    nm_paciente = doc.GetValue("nm_paciente", "").AsString,
                    nr_cpf = doc.GetValue("nr_cpf", "").AsString,
                    dt_data_raio_x = doc.GetValue("dt_data_raio_x").ToUniversalTime(),
                    ds_raio_x = doc.GetValue("ds_raio_x", "").AsString,
                    dt_analise_raio_x = doc.GetValue("dt_analise_raio_x").ToUniversalTime(),
                    ds_analise_raio_x = doc.GetValue("ds_analise_raio_x", "").AsString,
                    nm_plano = doc.GetValue("nm_plano", "").AsString,
                    nr_total_raio_x_analisados = 1,
                    ds_descricao_analise = doc.GetValue("ds_analise_raio_x", "").AsString
                });
            }

            return output;
        }
    }
}
