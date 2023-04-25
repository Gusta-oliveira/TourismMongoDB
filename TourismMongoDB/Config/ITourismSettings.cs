namespace TourismMongoDB.Config
{
    public interface ITourismSettings
    {
        string CustomerCollectionName { get; set; }
        string CityCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
