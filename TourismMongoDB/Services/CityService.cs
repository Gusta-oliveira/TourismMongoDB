using MongoDB.Driver;
using TourismMongoDB.Config;
using TourismMongoDB.Models;

namespace TourismMongoDB.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(ITourismSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() => _city.Find(c => true).ToList();
        public City Get(string id) => _city.Find<City>(c => c.Id == id).FirstOrDefault();
        public City Create(City city)
        {
            _city.InsertOne(city);
           return city;
        }
        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);
        public void Delete(City city) => _city.DeleteOne(c => c.Id == city.Id);

    }

}
