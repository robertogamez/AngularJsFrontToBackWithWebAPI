using APM.WebApi.Models;
using APM.WebAPI.Models;
using System.Collections.Generic;
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

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
