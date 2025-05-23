using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApplicationOdontoPrev.Models
{
    public class Auditoria
    {
        [BsonId]
        public ObjectId IdAuditoria { get; set; }

        [BsonElement("nm_tabela")]
        public string NmTabela { get; set; } = string.Empty;

        [BsonElement("ds_operacao")]
        public string DsOperacao { get; set; } = string.Empty;

        [BsonElement("dt_operacao")]
        public DateTime DtOperacao { get; set; }

        [BsonElement("id_usuario")]
        public string IdUsuario { get; set; } = string.Empty;

        [BsonElement("nm_valores_anteriores")]
        public string NmValoresAnteriores { get; set; } = string.Empty;
    }
}
