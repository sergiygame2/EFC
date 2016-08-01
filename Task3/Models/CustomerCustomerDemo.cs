using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class CustomerCustomerDemo
    {
        [Column("CustomerID", TypeName = "char")]
        public string CustomerId { get; set; }
        [Column("CustomerTypeID", TypeName = "char")]
        public string CustomerTypeId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerCustomerDemo")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("CustomerTypeId")]
        [InverseProperty("CustomerCustomerDemo")]
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
