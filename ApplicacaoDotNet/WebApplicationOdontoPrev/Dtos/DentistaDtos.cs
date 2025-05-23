using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplicationOdontoPrev.Models
{
    public class DentistaDtos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("nm_dentista")]
        public string nm_dentista { get; set; } = string.Empty;

        [BsonElement("ds_cro")]
        public string ds_cro { get; set; } = string.Empty;

        [BsonElement("ds_email")]
        public string ds_email { get; set; } = string.Empty;

        [BsonElement("nr_telefone")]
        public string nr_telefone { get; set; } = string.Empty;

        [BsonElement("ds_doc_identificacao")]
        public string ds_doc_identificacao { get; set; } = string.Empty;
    }
}
