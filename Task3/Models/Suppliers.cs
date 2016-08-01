using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        [Column("SupplierID", TypeName = "int")]
        public long SupplierId { get; set; }
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
        [Column(TypeName = "nvarchar")]
        public string HomePage { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
