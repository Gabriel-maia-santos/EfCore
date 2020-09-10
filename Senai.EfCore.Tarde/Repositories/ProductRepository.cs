using Senai.EfCore.Tarde.Contexts;
using Senai.EfCore.Tarde.Domains;
using Senai.EfCore.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.EfCore.Tarde.Repositories
{
    public class ProductRepository : IProductRepository {
        private readonly RequestContext _ctx;
        public ProductRepository() {
            _ctx = new RequestContext();
        }

        #region Reading
        // List all registered products
        public List<Product> List() {
            try {
                return _ctx.Products.ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        // Search for a product by Id
        public Product SearchById(Guid id) {
            try {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                return _ctx.Products.Find(id);
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }


        // Search products by name
        public List<Product> BuscarPorNome(string name) {
            try {
                return _ctx.Products.Where(c => c.Name.Contains(name)).ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Recording

        // Edit a product
        public void Editar(Product product) {
            try {
                // Search product by id
                Product productTemp = SearchById(product.Id);

                // Check if product exists
                // If it doesn't exist, generate an exception
                if (productTemp == null)
                    throw new Exception("Produto não encontrado");

                //If it exists, change its properties
                productTemp.Name = product.Name;
                productTemp.Price = product.Price;

                // Change product in context
                _ctx.Products.Update(productTemp);
                // Save the context
                _ctx.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        // Add a new product
        public void Adicionar(Product product) {
            try {
                //Add product object to context dbset
                _ctx.Products.Add(product);

                //_ctx.Set<Product>().Add(product);
                //_ctx.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Save changes in context
                _ctx.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// Remove a product
        public void Remove(Guid id) {
            try {
                //Search product by id
                Product produtoTemp = SearchById(id);

                // Check if product exists
                // If it doesn't exist, generate an exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                // Remove the product from dbSet
                _ctx.Products.Remove(produtoTemp);
                // Save context changes
                _ctx.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


    public List<Product> SearchByName(string name) {
        throw new NotImplementedException();
    }

    public void Add(Product product) {
        throw new NotImplementedException();
    }

    public void Edit(Product product) {
        throw new NotImplementedException();
    }
    #endregion
}
}
