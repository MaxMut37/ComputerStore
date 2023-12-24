using ComputerStore.ModelsCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class UserService
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                // Hier können Sie NotifyPropertyChanged implementieren, um die Änderungen zu signalisieren
            }
        }
    }
}
