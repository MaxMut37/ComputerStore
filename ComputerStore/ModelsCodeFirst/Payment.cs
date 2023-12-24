namespace ComputerStore.ModelsCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IdPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [Required]
        [StringLength(3)]
        public string PaymentStatus { get; set; }

        public short? StringPaymentId { get; set; }

        public int UserId { get; set; }
    }
}
