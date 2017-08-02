using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiToken.Models;

namespace WebApiToken.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [Authorize(Roles = "admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            List<Product> products = new List<Product> 
            {
                new Product {Id = 1, Description = "Arroz", QuantityInStock = 1},
                new Product {Id = 2, Description = "Feijão", QuantityInStock = 2},
                new Product {Id = 3, Description = "Óleo de Cozinha", QuantityInStock = 4 },
                new Product {Id = 4, Description = "Sabão em pó", QuantityInStock = 1},
                new Product {Id = 5, Description = "Detergente", QuantityInStock = 3}
            };

            return Ok(products);
        }
    }
}
