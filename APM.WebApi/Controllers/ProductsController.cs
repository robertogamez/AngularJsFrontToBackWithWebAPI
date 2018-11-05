using APM.WebApi.Models;
using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:64351", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            var productRepository = new ProductRepository();

            return productRepository.Retrieve();
        }

        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }
    }
}
