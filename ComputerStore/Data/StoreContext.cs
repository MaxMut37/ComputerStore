using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.ModelsCodeFirst;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-3VHEUSTB;Initial Catalog=ComputerHardwareStore;Integrated Security=True;");
        }

        public bool IsUserCredentialsValid(string login, string password)
        {
            // Используйте LINQ-запрос для проверки наличия пользователя с указанным логином и паролем
            bool isValidUser = User.Any(u => u.Login == login && u.Password == password);

            return isValidUser;
        }
    }
}
