using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerStore.ViewModel
{
    public class CustomOrderLine
    {
        public CustomOrderLine()
        {
            DecreaseQuantityCommand = new RelayCommand(DecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity);
            DeleteOrderLine = new RelayCommand(Delete);
        }

        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int? OrderLineId { get; set; }

        public ICommand DecreaseQuantityCommand { get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DeleteOrderLine { get; set; }

        public event EventHandler<CustomOrderLine> QuantityChanged;

        void DecreaseQuantity(object parameter)
        {
            QuantityChanged?.Invoke(this, this);
        }

        void IncreaseQuantity(object parameter)
        {

        }

        void Delete(object parameter)
        {

        }
    }
}
