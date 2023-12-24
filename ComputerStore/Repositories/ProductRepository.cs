using ComputerStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.ModelsCodeFirst;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Entity.Migrations;


namespace ComputerStore.Repositories
{
    public class ProductRepository
    {
        private readonly Model1 _dbContext; // Замените YourDbContext на ваш контекст базы данных

        public ProductRepository()
        {
            _dbContext = new Model1(); // Создайте экземпляр вашего контекста базы данных
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Product.Single(e => e.IdProduct == id);
        }
        public List<Product> GetProducts()
        {
            // Пример получения продуктов из базы данных с использованием Entity Framework
            return _dbContext.Product.ToList();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Product.AddOrUpdate(product);
            _dbContext.SaveChanges();
        }
        public void AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
        }
    }
}
