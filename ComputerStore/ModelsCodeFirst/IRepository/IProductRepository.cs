using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ModelsCodeFirst.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void AddProduct(Product product);

        Product GetProductById(int id);
    }
}
