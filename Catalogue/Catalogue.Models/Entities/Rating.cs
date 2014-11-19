namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        [Key]
        public int RatingID { get; set; }

        public int UserID { get; set; }

        public int Value { get; set; }

        public int ProductID { get; set; }

        public virtual Product Products { get; set; }

        public virtual User Users { get; set; }
    }
}
