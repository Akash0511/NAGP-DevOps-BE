using MongoDB.Driver;
using NagpDevOpsApp.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NagpDevOpsApp.Models
{
    public class ProductContext : IProductContext
    {
        private readonly IMongoDatabase _db;

        public ProductContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Product> Products => _db.GetCollection<Product>("Products");
    }
}
