namespace ComputerStore.ModelsCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StringPayment")]
    public partial class StringPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IdStringPayment { get; set; }

        public int Cost { get; set; }

        public int Count { get; set; }

        public short HardwareId { get; set; }
    }
}
