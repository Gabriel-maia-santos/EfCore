using Senai.EfCore.Tarde.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Tarde.Interfaces
{
    public interface IProductRepository
    {
        List<Product> List();
        Product SearchById(Guid id);
        List<Product> SearchByName(string name);
        void Add(Product product);
        void Edit(Product product);
        void Remove(Guid id);
    }
}
