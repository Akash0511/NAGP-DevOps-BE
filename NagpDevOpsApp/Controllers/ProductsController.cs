using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagpDevOpsApp.Models;
using NagpDevOpsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NagpDevOpsApp.Repositories;

namespace NagpDevOpsApp.Controllers
{
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("hello")]
        public string HelloWorld()
        {
            return "Hello";
        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return new ObjectResult(await _repo.GetAllProducts());
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            product.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            await _repo.Create(product);
            return new OkObjectResult(product);
        }
    }
}
