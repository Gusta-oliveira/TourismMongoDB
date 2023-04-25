using MongoDB.Driver;
using TourismMongoDB.Config;
using TourismMongoDB.Models;

namespace TourismMongoDB.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(ITourismSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }
        public List<Address> Get() => _address.Find(a => true).ToList();

        public Address Get(string id) => _address.Find<Address>(a => a.Id == id).FirstOrDefault();

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }


    }
}
