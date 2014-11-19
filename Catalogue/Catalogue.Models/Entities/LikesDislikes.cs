namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LikesDislikes
    {
        [Key]
        public int LikeDislikeID { get; set; }

        public int UserID { get; set; }

        public bool IsLike { get; set; }

        public int ProductID { get; set; }

        public virtual Products Products { get; set; }

        public virtual Users Users { get; set; }
    }
}
