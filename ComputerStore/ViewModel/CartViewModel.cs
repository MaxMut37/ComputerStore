using ComputerStore.ModelsCodeFirst;
using ComputerStore.ModelsCodeFirst.IRepository;
using ComputerStore.Repositories;
using ComputerStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ComputerStore.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        public ProductRepository productRepository;
        public CartRepository cartRepository;
        public ObservableCollection<Cart> carts { get; set; }
        public ObservableCollection<Product> customOrderLine { get; set; }
        private User user;
       
        public UserRepository _userRepository;
        //public ObservableCollection<ProductTable> _products { get; set; }
        public ICommand AddProductCommand { get; }
        public ICommand OpenPage { get; }
        public ICommand IncreaseTheNumberCommand { get; }
        public ICommand ReduceTheNumberCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand ProductDetailsCommand { get; }

        public CartViewModel()
        {
            productRepository = new ProductRepository();
            _userRepository = new UserRepository();
            cartRepository = new CartRepository();
            user = _userRepository.GetUserByUserName(ComputerStore.Properties.Settings.Default.Login);
            carts = new ObservableCollection<Cart>(cartRepository.GetProductsFromCart(user.IdUser));
            IncreaseTheNumberCommand = new ViewModelCommand(ExecuteIncreaseTheNumberCommand);
            ReduceTheNumberCommand = new ViewModelCommand(ExecuteReduceTheNumberCommand);
            //GetProductsFromCart
            AddToCartCommand = new ViewModelCommand(ExecuteAddToCartCommand, CanExecuteAddToCartCommand);

            AddProductCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
            
            //LoadProducts();
            
        }

        

        private void ExecuteReduceTheNumberCommand(object obj)
        {
            var cart = carts.Where(i => i.ProductId == (int)obj).First();

            cart.AmountProduct -= 1;
            cartRepository.UpdateCart(cart);
        }

        private void ExecuteIncreaseTheNumberCommand(object obj)
        {
            var cart = carts.Where(i => i.ProductId == (int)obj).First();

            cart.AmountProduct += 1;
            cartRepository.UpdateCart(cart);
        }

        private bool CanExecuteAddToCartCommand(object obj)
        {
            return true;
        }


        private void ExecuteAddToCartCommand(object obj)
        {
            var user = _userRepository.GetUserByUserName(ComputerStore.Properties.Settings.Default.Login);

            MessageBox.Show(user.IdUser.ToString());
            MessageBox.Show(user.Login.ToString());
            MessageBox.Show(user.UserStatus.ToString());
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var cartView = new CartView();
            cartView.Show();

            //AddToCartCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand); 
        }

        private void ExecuteRegistrationCommand(object obj)
        {
            var addProductView = new AddProductView();
            addProductView.Show();
        }

        private bool CanExecuteRegistrationCommand(object obj)
        {
            return true;
        }

        //private void LoadProducts()
        //{
        //    products.Clear();
        //    List<Product> productsList;
        //    productsList = productRepository.GetProducts();
        //    foreach (Product product in productsList)
        //    {
        //        products.Add(product);
        //    }
        //}
    }
}
