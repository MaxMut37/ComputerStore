namespace ComputerStore.ModelsCodeFirst
{
    using ComputerStore.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Input;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Cost { get; set; }

        [Required]
        [StringLength(250)]
        public string Specifications { get; set; }

        public int Count { get; set; }

        public byte[] Image { get; set; }

        public decimal? ImageSize { get; set; }

        [StringLength(10)]
        public string FileExtention { get; set; }

        public string Pathes { get; set; }
    }
}
