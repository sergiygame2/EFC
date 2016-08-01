using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
        [Required]
        [Column(TypeName = "char")]
        public string RegionDescription { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Territories> Territories { get; set; }
    }
}
