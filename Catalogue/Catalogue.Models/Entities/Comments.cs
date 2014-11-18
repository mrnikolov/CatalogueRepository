namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        public int CommentID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public int ProductID { get; set; }

        public int? ParentCommentID { get; set; }

        public virtual Comments ParentComment { get; set; }

        public virtual Products Products { get; set; }

        public virtual Users Users { get; set; }
    }
}
