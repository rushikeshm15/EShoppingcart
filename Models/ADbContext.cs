using System.Data.Entity;

namespace eshopping.Models
{
    public class ADbContext : DbContext
    {
        public DbSet<user_details> userdetails { get; set; }

    }
}