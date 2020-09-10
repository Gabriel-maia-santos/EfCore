using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Tarde.Domains
{
    public class Request : BaseDomain
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
