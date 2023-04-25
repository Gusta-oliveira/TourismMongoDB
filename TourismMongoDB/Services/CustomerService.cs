using MongoDB.Driver;
using TourismMongoDB.Config;
using TourismMongoDB.Models;

namespace TourismMongoDB.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _client;
        public CustomerService(ITourismSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }
    }
}
