using MongoDB.Driver;

namespace Catalog_Web_API_Demo.Settings;

public class MongoDBSettings
{
    public string Host { get; set; }

    public int Port { get; set; }

    public string ConnectionString { get
        {
            return $"mongodb://{Host}:{Port}";
        } 
    }
}
