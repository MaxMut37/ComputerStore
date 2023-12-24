using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string UserStatus { get; set; }

    }
}
