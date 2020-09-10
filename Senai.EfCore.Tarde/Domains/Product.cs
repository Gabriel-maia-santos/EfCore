using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Tarde.Domains
{
    public class Product : BaseDomain
    {

        public string Name { get; set; }
        public float Price { get; set; }

    }
}
