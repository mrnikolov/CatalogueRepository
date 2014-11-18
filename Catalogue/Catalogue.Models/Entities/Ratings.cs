namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ratings
    {
        [Key]
        public int RatingID { get; set; }

        public int UserID { get; set; }

        public int Value { get; set; }

        public int ProductID { get; set; }

        public virtual Products Products { get; set; }

        public virtual Users Users { get; set; }
    }
}
