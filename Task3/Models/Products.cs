using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductCategoryMap = new HashSet<ProductCategoryMap>();
        }

        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string ProductName { get; set; }
        [Column("SupplierID", TypeName = "int")]
        public long? SupplierId { get; set; }
        [Column("CategoryID", TypeName = "int")]
        public long? CategoryId { get; set; }
        [Column(TypeName = "nvarchar")]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "decimal")]
        public string UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsInStock { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsOnOrder { get; set; }
        [Column(TypeName = "smallint")]
        public long? ReorderLevel { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public string Discontinued { get; set; }
        [Column("AttributeXML", TypeName = "varchar")]
        public string AttributeXml { get; set; }
        [Column(TypeName = "datetime")]
        public string DateCreated { get; set; }
        [Column("ProductGUID", TypeName = "uniqueidentifier")]
        public string ProductGuid { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public string CreatedOn { get; set; }
        [Column(TypeName = "nvarchar")]
        public string CreatedBy { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public string ModifiedOn { get; set; }
        [Column(TypeName = "nvarchar")]
        public string ModifiedBy { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public string Deleted { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductCategoryMap> ProductCategoryMap { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Categories Category { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Products")]
        public virtual Suppliers Supplier { get; set; }
    }
}
