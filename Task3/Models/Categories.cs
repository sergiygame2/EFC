using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategoryMap = new HashSet<ProductCategoryMap>();
            Products = new HashSet<Products>();
        }

        [Column("CategoryID", TypeName = "int")]
        public long CategoryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string CategoryName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }
        [Column(TypeName = "blob")]
        public byte[] Picture { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<ProductCategoryMap> ProductCategoryMap { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
