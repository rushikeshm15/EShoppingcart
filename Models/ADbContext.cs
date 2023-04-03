using System.Data.Entity;


namespace eshopping.Models
{
    public class ADbContext : DbContext
    {
        public DbSet<user_details> userdetails { get; set; }


        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<user_details>()
                .Property(p => p.Isadmin)
                .HasColumnAnnotation("DefaultValue", false);
        }


    }


}