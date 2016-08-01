using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
            Orders = new HashSet<Orders>();
        }

        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar")]
        public string TitleOfCourtesy { get; set; }
        [Column(TypeName = "datetime")]
        public string BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public string HireDate { get; set; }
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
        public string HomePhone { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Extension { get; set; }
        [Column(TypeName = "blob")]
        public byte[] Photo { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Notes { get; set; }
        [Column(TypeName = "int")]
        public long? ReportsTo { get; set; }
        [Column(TypeName = "nvarchar")]
        public string PhotoPath { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public string Deleted { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Orders> Orders { get; set; }
        [ForeignKey("ReportsTo")]
        [InverseProperty("InverseReportsToNavigation")]
        public virtual Employees ReportsToNavigation { get; set; }
        [InverseProperty("ReportsToNavigation")]
        public virtual ICollection<Employees> InverseReportsToNavigation { get; set; }
    }
}
