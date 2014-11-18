namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public Products()
        {
            Comments = new HashSet<Comments>();
            Images = new HashSet<Images>();
            LikesDislikes = new HashSet<LikesDislikes>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductsTags = new HashSet<ProductsTags>();
            Ratings = new HashSet<Ratings>();
            Wishlists = new HashSet<Wishlists>();
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

        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<Images> Images { get; set; }

        public virtual ICollection<LikesDislikes> LikesDislikes { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }

        public virtual ICollection<ProductsTags> ProductsTags { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; }

        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
