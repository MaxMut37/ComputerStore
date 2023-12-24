using System;
using ComputerStore.Repositories;
using ComputerStore.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ComputerStore.ModelsCodeFirst;
using System.Windows.Controls;
using System.Diagnostics;
using ComputerStore.ModelsCodeFirst.IRepository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ComputerStore.Services;

namespace ComputerStore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ProductRepository productRepository;
        private User _user;

        private readonly UserService _userService;

        public UserRepository _userRepository;

        public CartRepository _cartRepository;
        private bool _isViewVisible = true;

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public ObservableCollection<Product> products { get; set; }
        public ObservableCollection<Product> customOrderLine { get; set; }
        public ICommand AddProductCommand { get; }
        public ICommand OpenCartCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand ProductDetailsCommand { get; }
        public User User 
        {
            get 
            { 
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
           
        }

        public MainViewModel(/*UserService userService*/)
        {
            _userRepository = new UserRepository();
            //LoadUserData();

            //_userService = userService;
            _cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            products = new ObservableCollection<Product>();
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand, CanExecuteRegistrationCommand);

            LoadProducts();

            OpenCartCommand = new ViewModelCommand(ExecuteOpenCartCommand, CanExecuteRegistrationCommand);
            AddToCartCommand = new ViewModelCommand(ExecuteAddToCartCommand);
            EditProductCommand = new ViewModelCommand(ExecuteEditToCartCommand);
        }

        private void ExecuteEditToCartCommand(object obj)
        {
            ComputerStore.Properties.Settings.Default.IdProduct = (int)obj;
            ComputerStore.Properties.Settings.Default.Save();
            var editProductView = new EditProductView();
            editProductView.Show();
        }

        private void ExecuteAddToCartCommand(object obj)
        {
            Product product = (Product)obj;
            var user = _userRepository.GetUserByUserName(ComputerStore.Properties.Settings.Default.Login);
            
            var cart = _cartRepository.GetCartOnProduct(user.IdUser, product.IdProduct);

            if (cart != null)
            {
                cart.AmountProduct += 1;
                _cartRepository.UpdateCart(cart);
            }
            else
            {
                Cart cartNew = new Cart();
                cartNew.UserId = user.IdUser;
                cartNew.ProductId = product.IdProduct;
                cartNew.AmountProduct = 1;

                _cartRepository.UpdateCart(cartNew);
            }
        }
        private void ExecuteAddProductCommand(object obj)
        {
            var addProductView = new AddProductView();
            addProductView.Show();
        }

        

        private void ExecuteOpenCartCommand(object obj)
        {
            var cartView = new CartView();
            cartView.Show();
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



        private bool CanExecuteRegistrationCommand(object obj)
        {
            return true;
        }

        private void LoadProducts()
        {
            products.Clear();
            List<Product> productsList;
            productsList = productRepository.GetProducts();
            foreach (Product product in productsList)
            {
                products.Add(product);
            }
        }
    }
}
