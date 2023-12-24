using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ComputerStore.ModelsCodeFirst
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<StringPayment> StringPayment { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Cost);


            modelBuilder.Entity<Product>()
                .Property(e => e.Count);


            modelBuilder.Entity<Product>()
                .Property(e => e.ImageSize)
                .HasPrecision(18, 0);
        }
    }
}
