using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Territories
    {
        public Territories()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
        }

        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "char")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }

        [InverseProperty("Territory")]
        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        [ForeignKey("RegionId")]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
    }
}
