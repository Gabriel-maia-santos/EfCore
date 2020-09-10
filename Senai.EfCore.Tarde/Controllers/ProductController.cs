using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Tarde.Domains;
using Senai.EfCore.Tarde.Interfaces;
using Senai.EfCore.Tarde.Repositories;

namespace Senai.EfCore.Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productRepository.List();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _productRepository.SearchById(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post(Product product)
        {
            _productRepository.Add(product);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Product product)
        {
            product.Id = id;
            _productRepository.Edit(product);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _productRepository.Remove(id);
        }
    }
}
