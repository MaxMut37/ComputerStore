using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ModelsCodeFirst
{
    [Table("Cart")]
    public class Cart
    {

        //public int IdCart { get; set; }
        [Key]
       // [Column(Order = 1)]
        public int UserId { get; set; }
       // [Key]
        //[Column(Order = 2)]
        public int ProductId { get; set; }

        public int AmountProduct { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product product { get; set; }
    }
}
