using Microsoft.EntityFrameworkCore;
using Senai.EfCore.Tarde.Domains;

namespace Senai.EfCore.Tarde.Contexts
{
    public class RequestContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RequestItem> RequestItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress; Initial Catalog=Db_Senai_Pedidos_Tarde_Dev; user id=sa; password=sa@132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
