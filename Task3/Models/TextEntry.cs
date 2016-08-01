using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFfromDB.Models
{
    public partial class TextEntry
    {
        [Column("contentID", TypeName = "int")]
        public long ContentId { get; set; }
        [Required]
        [Column("contentGUID", TypeName = "uniqueidentifier")]
        public string ContentGuid { get; set; }
        [Column("title", TypeName = "nvarchar")]
        public string Title { get; set; }
        [Required]
        [Column("contentName", TypeName = "nvarchar")]
        public string ContentName { get; set; }
        [Column("content", TypeName = "nvarchar")]
        public string Content { get; set; }
        [Column("iconPath", TypeName = "nvarchar")]
        public string IconPath { get; set; }
        [Column("dateExpires", TypeName = "datetime")]
        public string DateExpires { get; set; }
        [Column("lastEditedBy", TypeName = "nvarchar")]
        public string LastEditedBy { get; set; }
        [Column("externalLink", TypeName = "nvarchar")]
        public string ExternalLink { get; set; }
        [Column("status", TypeName = "nvarchar")]
        public string Status { get; set; }
        [Column("listOrder", TypeName = "int")]
        public long ListOrder { get; set; }
        [Column("callOut", TypeName = "nvarchar")]
        public string CallOut { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public string CreatedOn { get; set; }
        [Column("createdBy", TypeName = "nvarchar")]
        public string CreatedBy { get; set; }
        [Column("modifiedOn", TypeName = "datetime")]
        public string ModifiedOn { get; set; }
        [Column("modifiedBy", TypeName = "nvarchar")]
        public string ModifiedBy { get; set; }
    }
}
