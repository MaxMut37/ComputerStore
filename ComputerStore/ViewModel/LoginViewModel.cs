using ComputerStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ComputerStore.Repositories;   
using System.Threading;
using System.Security.Principal;
using ComputerStore.View;
using System.Windows;
using ComputerStore.Services;
using ComputerStore.ModelsCodeFirst.IRepository;

namespace ComputerStore.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = "admin";
        private string _password = "admin";
        private string _errorMessage;
        private bool _isViewVisible = true;

       // private readonly UserService _userService;

        private UserRepository userRepository;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
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

        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }
       
        public LoginViewModel(/*UserService userService*/) 
        {
            //_userService = userService;
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
        }

        private bool CanExecuteRegistrationCommand(object obj)
        {
            return true;
        }

        private void ExecuteRegistrationCommand(object obj)
        {
            var registrationView = new RegistrationView();
            registrationView.Show();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) ||
                Password == null || Username == null ||
                                   Username.Length < 4 || Password.Length < 4)
            {
                validData = false;
            }
            else
            { 
                validData= true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
                //var user = userRepository.GetUserByUserName(ComputerStore.Properties.Settings.Default.Login);
                ComputerStore.Properties.Settings.Default.Login = Username;
                ComputerStore.Properties.Settings.Default.Save();
                //_userService.CurrentUser = authenticatedUser;
            }
            else 
            {
                ErrorMessage = "Invalid username or password";
            }
        }        
    }
}
