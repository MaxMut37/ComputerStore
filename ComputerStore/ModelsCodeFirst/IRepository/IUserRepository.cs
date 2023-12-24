using ComputerStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerStore.ModelsCodeFirst.IRepository
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        //void AddUser(User user);
        void AddUser(User user);
        User GetUserByUserName(string userName);

        //User GetByUserName(string userName);

        User ReturnUser(string UserName, string Password);
       

       

        
    }
}
