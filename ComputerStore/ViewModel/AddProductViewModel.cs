using ComputerStore.Core;
using ComputerStore.Repositories;
using ComputerStore.ModelsCodeFirst.IRepository;
using ComputerStore.ModelsCodeFirst;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using ComputerStore.Model;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Shapes;
using System.Threading;
using User = ComputerStore.ModelsCodeFirst.User;
using ComputerStore.Services;
using System.Security.Principal;

namespace ComputerStore.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        //private readonly CategoriesRepository _categoriesRepository;
        public UserRepository _userRepository;
        private readonly ProductRepository _productsRepository;

        private Product _product;

        private User _user;

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

        public AddProductViewModel()
        {

            _productsRepository = new ProductRepository();
             _userRepository = new UserRepository();

            //LoadUserData();
            _product = new Product();

            _product.Pathes = "/Images/defaultProductImage.jpg" ; // Default image for new product

            SelectedProduct = new Product();

        }
         
        public string Pathes
        {
            get { return _product.Pathes; }
            set
            {
                _product.Pathes = value;
                OnPropertyChanged("Pathes");
            }
        }
        public string Specifications
        {
            get { return _product.Specifications; }
            set
            {
                _product.Specifications = value;
                OnPropertyChanged("Specifications");
            }
        }

        
        public string Name
        {
            get { return _product.Name; }
            set
            {
                _product.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Cost
        {
            get { return _product.Cost; }
            set
            {
                _product.Cost = value;
                OnPropertyChanged("Cost");
            }
        }
        public int Count
        {
            get { return _product.Count; }
            set
            {
                _product.Count = value;
                OnPropertyChanged("Count");
            }
        }
       
        private readonly RelayCommand _addProduct;
        public RelayCommand AddProduct
        {
            get
            {
                return _addProduct ?? (new RelayCommand(obj =>
                {
                
                            _productsRepository.AddProduct(_product);

                    MessageBox.Show($"{_product.Name} Added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }));
            }
        }
        private readonly RelayCommand _openFileDialog;

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public RelayCommand OpenFileDialog
        {
            get
            {
                return _openFileDialog ?? (new RelayCommand(obj =>
                {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = true;
                ofd.Title = "Выберите фотографию товара";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.apng;*.avif;*.gif;*.jfif;*.pjpeg";
                ofd.ShowDialog();
                if (ofd.FileNames.Count() == 1)
                    Pathes = ofd.FileName;
                    if (Pathes.Length > 0)
                    {
                        byte[] buff;
                        if (File.Exists(Pathes))
                        {
                            buff = File.ReadAllBytes(Pathes);
                            System.Drawing.Image img = Image.FromFile(Pathes);
                            Bitmap resizedImage = new Bitmap(img, new System.Drawing.Size(256, 256));
                            using (var stream = new MemoryStream())
                            {
                                resizedImage.Save(stream, ImageFormat.Jpeg);
                                byte[] bytes = stream.ToArray();

                                _product.FileExtention = System.IO.Path.GetExtension(Pathes);
                                _product.Image = bytes;
                                _product.ImageSize = bytes.Length;
                            }
                        }
                    }
                }));
            }
        }
    }
}

