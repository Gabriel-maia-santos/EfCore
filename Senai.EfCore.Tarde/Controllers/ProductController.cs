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
    public class ProductController : ControllerBase {
        private readonly IProductRepository _productRepository;

        public ProductController() {
            _productRepository = new ProductRepository();
        }
        [HttpGet]
        public IActionResult Get() {
            try {
                // List the products
                var products = _productRepository.List();


                // Check if there is a registered product
                if (products.Count == 0)
                    return NoContent();

                return Ok(new {
                    totalCount = products.Count,
                    data = products
                });
            }
            catch (Exception ex) {
                // TODO: Register error message in the logError domain
                return BadRequest(new {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/products, envie um e-mail para email@email.com informando"
                });
            }
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]

        public IActionResult Get(Guid id) {
            try {
                //Busco o produto pelo Id
                Product product = _productRepository.SearchById(id);

                //Verifico se o produto foi encontrado
                //Caso não exista retorno NotFounf
                if (product == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do produto
                return Ok(product);
            }
            catch (Exception ex) {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }
        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Product product) {
            try {
                //Add a new product
                _productRepository.Add(product);

                // Returns Ok
                return Ok(product);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Product product) {
            try {
                // Edit the product
                _productRepository.Edit(product);

                // Returns Ok with the product data
                return Ok(product);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            try {
                // Search the product by Id
                var product = _productRepository.SearchById(id);

                //Checks whether product exists
                //If not, return NotFound
                if (product == null)
                    return NotFound();

                //If it exists remove the product
                _productRepository.Remove(id);
                //Return
                return Ok(id);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
