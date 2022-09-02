using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using NagpDevOpsApp.Models;

namespace NagpDevOpsApp.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;
        public ProductService(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);

        }

        public List<Product> Get()
        {
            List<Product> products;
            products = _products.Find(product => true).ToList();
            return products;
        }

        public async Task CreateAsync(Product newProduct) =>
        await _products.InsertOneAsync(newProduct);

    }
}
