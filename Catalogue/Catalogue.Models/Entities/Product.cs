namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            LikesDislikes = new HashSet<LikeDislike>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductsTags = new HashSet<ProductTag>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        public int ManufacturerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProductYear { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<LikeDislike> LikesDislikes { get; set; }

        public virtual Manufacturer Manufacturers { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }

        public virtual ICollection<ProductTag> ProductsTags { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
