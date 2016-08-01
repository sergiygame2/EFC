using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    [Table("Product_Category_Map")]
    public partial class ProductCategoryMap
    {
        [Column("CategoryID", TypeName = "int")]
        public long CategoryId { get; set; }
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("ProductCategoryMap")]
        public virtual Categories Category { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("ProductCategoryMap")]
        public virtual Products Product { get; set; }
    }
}
