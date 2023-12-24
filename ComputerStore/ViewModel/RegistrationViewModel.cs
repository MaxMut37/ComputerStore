
using ComputerStore.Repositories;
using ComputerStore.View;
using System;
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


namespace ComputerStore.ViewModel
{
    internal class RegistrationViewModel : ViewModelBase
    {
        private string _usernameReg = "admin";
        private string _passwordReg = "admin";
        private string _selectedUserType;
        private string _errorMessageReg;
        private bool _isViewVisibleReg = true;

        private UserRepository userRepository;
        private ObservableCollection<String> _userTypes;

        public ObservableCollection<string> UserTypes
        {
            get
            {
                return _userTypes;
            }
            set
            {
                _userTypes = value;
                OnPropertyChanged(nameof(UserTypes));
            }

        }

        public string SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                _selectedUserType = value;
                
                OnPropertyChanged(nameof(SelectedUserType));
            }
        }

        public string UsernameReg
        {
            get { return _usernameReg; }
            set
            {
                _usernameReg = value;
                OnPropertyChanged(nameof(UsernameReg));
            }
        }

        public string PasswordReg
        {
            get { return _passwordReg; }
            set
            {
                _passwordReg = value;
                OnPropertyChanged(nameof(_passwordReg));
            }
        }

        public string ErrorMessageReg
        {
            get { return _errorMessageReg; }
            set
            {
                _errorMessageReg = value;
                OnPropertyChanged(nameof(ErrorMessageReg));
            }
        }

        public bool IsViewVisibleReg
        {
            get { return _isViewVisibleReg; }
            set
            {
                _isViewVisibleReg = value;
                OnPropertyChanged(nameof(IsViewVisibleReg));
            }
        }

        public ICommand RegistrationCommand { get; }
        
        public RegistrationViewModel()
        {
            userRepository = new UserRepository();
            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
            _userTypes = new ObservableCollection<string>();
            _userTypes.Add("Seller");
            _userTypes.Add("Buyer");
        }
        private void ExecuteRegistrationCommand(object obj)
        {

            userRepository.AddUser(new User
            {
                Login = UsernameReg,
                Password = PasswordReg,
                UserStatus = SelectedUserType
            });

            var registrationView = new RegistrationView();
            registrationView.ShowDialog();
            registrationView.IsVisibleChanged += (s, ev) =>
            {
                if (!registrationView.IsVisible && registrationView.IsLoaded)
                {
                    var loginView = new LoginView();
                    loginView.Show();
                    registrationView.Close();
                }
            };
        }

        private bool CanExecuteRegistrationCommand(object obj)
        {
            bool validData = !string.IsNullOrWhiteSpace(UsernameReg) &&
                             !string.IsNullOrWhiteSpace(PasswordReg) &&
                             UsernameReg.Length >= 4 && PasswordReg.Length >= 4;

            if (!validData)
            {
                ErrorMessageReg = "Please enter a valid username and password.";
                return false;
            }

            if (string.IsNullOrEmpty(SelectedUserType))
            {
                ErrorMessageReg = "Please select a user type.";
                return false;
            }

            ErrorMessageReg = ""; // Clear the error message if all checks pass
            return true;
        }
    }
}

