using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Shippers
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Column("ShipperID", TypeName = "int")]
        public long ShipperId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string CompanyName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Phone { get; set; }

        [InverseProperty("ShipViaNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
