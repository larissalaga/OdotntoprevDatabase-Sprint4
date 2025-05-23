using MongoDB.Driver;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Data
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }

        public MongoContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            Database = client.GetDatabase("ODONTOPREV");
        }

        public IMongoCollection<Paciente> Pacientes => Database.GetCollection<Paciente>("PACIENTES");
        public IMongoCollection<Dentista> Dentistas => Database.GetCollection<Dentista>("DENTISTAS");
    }
}
