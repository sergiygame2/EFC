using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Column("CustomerID", TypeName = "char")]
        public string CustomerId { get; set; }
        [Column("EmployeeID", TypeName = "int")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public string OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public string RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public string ShippedDate { get; set; }
        [Column(TypeName = "int")]
        public long? ShipVia { get; set; }
        [Column(TypeName = "decimal")]
        public string Freight { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipAddress { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipCity { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipRegion { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipPostalCode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ShipCountry { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("Orders")]
        public virtual Employees Employee { get; set; }
        [ForeignKey("ShipVia")]
        [InverseProperty("Orders")]
        public virtual Shippers ShipViaNavigation { get; set; }
    }
}
