using ComputerStore.Data;
using ComputerStore.ModelsCodeFirst.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComputerStore.ModelsCodeFirst;


namespace ComputerStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Model1 _dbContext; 

        public UserRepository()
        {
            _dbContext = new Model1(); 
        }

        public void AddUser(User user)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var userEntity = new User
                    {
                        Login = user.Login,
                        Password = user.Password,
                        UserStatus = user.UserStatus
                    };

                    context.User.Add(userEntity);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public User GetUserByUserName(string Login)
        {
            return _dbContext.User.Single(e => e.Login == Login);
        }
        public User ReturnUser(string UserName, string Password)
        {
            return _dbContext.User.Single(e=>e.Login == UserName);
        }

        public bool AuthenticateUser(NetworkCredential credential) // проверка на наличие пользователя (если данные о пользователе есть, то возвращается значение true)
        {
            // Check if there is any user with the provided login and password
            bool validUser = _dbContext.User.Any(u => u.Login == credential.UserName && u.Password == credential.Password);

            return validUser;
        }

        //public bool ReturnUserName(NetworkCredential credential) // проверка на наличие пользователя (если данные о пользователе есть, то возвращается значение true)
        //{
        //    // Check if there is any user with the provided login and password
        //    User user = _dbContext.User.Single(u => u.Login == credential.UserName);
        //    if (user.Password == credential.Password)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
      


    }
}
