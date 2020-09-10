using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Tarde.Domains
{
    public class RequestItem : BaseDomain
    {
        
        public Guid IdRequest { get; set; }
        [ForeignKey("IdRequest")]
        public Request Request { get; set; }

        public Guid IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        
    }
}
