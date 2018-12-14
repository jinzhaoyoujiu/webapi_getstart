using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GetStart.Models;

namespace GetStart.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] {
            new Product{Id=1,Name="Tomato soup",Category="Groceries",Price=2 },
            new Product{Id=2,Name="Yo-yo",Category="Toys",Price=3 },
            new Product{Id=3,Name="Hammer",Category="Hardware",Price=4 }
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        public IHttpActionResult GetProduct(int id)
        {
            Product result = products.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            else {
                return Ok(result);
            }
        }
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        public void TestVoid()
        {
            
        }
        [HttpGet]
        public HttpResponseMessage TestResponseMessage()
        {
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK, "value");
            responseMessage.Content = new StringContent("hello", System.Text.Encoding.Unicode);



            responseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(1)
            };
            return responseMessage;
        }
    }
}