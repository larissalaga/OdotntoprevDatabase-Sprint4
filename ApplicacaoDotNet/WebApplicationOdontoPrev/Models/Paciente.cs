using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WebApplicationOdontoPrev.Models
{
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("nm_paciente")]
        public string nm_paciente { get; set; } = string.Empty;

        [BsonElement("nr_cpf")]
        public string nr_cpf { get; set; } = string.Empty;

        [BsonElement("dt_nascimento")]
        public DateTime dt_nascimento { get; set; }

        [BsonElement("ds_sexo")]
        public string ds_sexo { get; set; } = string.Empty;

        [BsonElement("ds_email")]
        public string ds_email { get; set; } = string.Empty;

        [BsonElement("nr_telefone")]
        public string nr_telefone { get; set; } = string.Empty;

        [BsonElement("PLANO")]
        public Plano PLANO { get; set; } = new();

        [BsonElement("CHECK_IN")]
        public List<CheckIn> CHECK_IN { get; set; } = new();

        [BsonElement("RAIO_X")]
        public List<RaioX> RAIO_X { get; set; } = new();

        [BsonElement("EXTRATO_PONTOS")]
        public List<ExtratoPontos> EXTRATO_PONTOS { get; set; } = new();

        [BsonElement("DENTISTA")]
        public List<DentistaResumo> DENTISTA { get; set; } = new();
    }

    public class Plano
    {
        [BsonElement("ds_codigo_plano")]
        public string ds_codigo_plano { get; set; } = string.Empty;

        [BsonElement("nm_plano")]
        public string nm_plano { get; set; } = string.Empty;
    }

    public class CheckIn
    {
        [BsonElement("data")]
        public DateTime data { get; set; }

        [BsonElement("pergunta")]
        public string pergunta { get; set; } = string.Empty;

        [BsonElement("resposta")]
        public string resposta { get; set; } = string.Empty;
    }

    public class RaioX
    {
        [BsonElement("ds_raio_x")]
        public string ds_raio_x { get; set; } = string.Empty;

        [BsonElement("im_raio_x")]
        public string im_raio_x { get; set; } = string.Empty;

        [BsonElement("dt_data_raio_x")]
        public DateTime dt_data_raio_x { get; set; }

        [BsonElement("analise")]
        public AnaliseRaioX analise { get; set; } = new();
    }

    public class AnaliseRaioX
    {
        [BsonElement("ds_analise_raio_x")]
        public string ds_analise_raio_x { get; set; } = string.Empty;

        [BsonElement("dt_analise_raio_x")]
        public DateTime dt_analise_raio_x { get; set; }
    }

    public class ExtratoPontos
    {
        [BsonElement("dt_extrato")]
        public DateTime dt_extrato { get; set; }

        [BsonElement("ds_movimentacao")]
        public string ds_movimentacao { get; set; } = string.Empty;

        [BsonElement("nr_numero_pontos")]
        public int nr_numero_pontos { get; set; }
    }

    public class DentistaResumo
    {
        [BsonElement("nm_dentista")]
        public string nm_dentista { get; set; } = string.Empty;

        [BsonElement("ds_cro")]
        public string ds_cro { get; set; } = string.Empty;
    }
}
