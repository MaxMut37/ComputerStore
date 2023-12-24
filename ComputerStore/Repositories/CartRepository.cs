using ComputerStore.Data;
using ComputerStore.Model;
using ComputerStore.ModelsCodeFirst;
using ComputerStore.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerStore.Repositories
{
    public class CartRepository
    {
        private readonly Model1 _dbContext;

        public CartRepository()
        {
            _dbContext = new Model1();
        }

        public List<Cart> GetProductsFromCart(int UserId)
        {
            return _dbContext.Cart.Include("product").Where(e => e.UserId == UserId).ToList();
        }
        public void UpdateCart(Cart cart)
        {
            _dbContext.Cart.AddOrUpdate(cart);
            _dbContext.SaveChanges();
        }
        public Cart GetCartOnProduct(int UserId, int ProductId)
        {
            return _dbContext.Cart.Find(UserId, ProductId);
        }
        public void AddCart(Cart cart)
        {
            _dbContext.Cart.Add(cart);
            _dbContext.SaveChanges();
        }
    }
}
