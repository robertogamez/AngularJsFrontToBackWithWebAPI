using APM.WebApi.Models;
using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:64351", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();

            return productRepository.Retrieve().AsQueryable();
        }

        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }

        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();

            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }

            return product;
        }

        public void Ppst([FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var updateProduct = productRepository.Save(id, product);
        }


    }
}
