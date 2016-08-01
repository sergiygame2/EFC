using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    [Table("Order Details")]
    public partial class OrderDetails
    {
        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "decimal")]
        public string UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long Quantity { get; set; }
        [Required]
        [Column(TypeName = "SINGLE")]
        public string Discount { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual Orders Order { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public virtual Products Product { get; set; }
    }
}
