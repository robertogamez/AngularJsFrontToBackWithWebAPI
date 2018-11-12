using APM.WebApi.Models;
using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:64351", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var productRepository = new ProductRepository();

                return Ok(productRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ResponseType(typeof(Product))]
        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();

                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);

                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);

                if (newProduct == null)
                {
                    return Conflict();
                }

                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                    newProduct);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productRepository = new ProductRepository();
            var updateProduct = productRepository.Save(id, product);

            if (updateProduct == null)
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
