using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Orders>();
        }

        [Column("CustomerID", TypeName = "char")]
        public string CustomerId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string CompanyName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ContactName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ContactTitle { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Region { get; set; }
        [Column(TypeName = "nvarchar")]
        public string PostalCode { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Fax { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
