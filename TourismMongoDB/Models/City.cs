using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TourismMongoDB.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentationAttribute(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
