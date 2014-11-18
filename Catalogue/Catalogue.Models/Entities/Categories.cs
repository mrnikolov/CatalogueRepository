namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        public Categories()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentCategoryID { get; set; }

        public virtual Categories ParentCategory { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
