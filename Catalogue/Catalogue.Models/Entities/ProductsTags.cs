namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductsTags
    {
        [Key]
        public int ProductTagID { get; set; }

        public int ProductID { get; set; }

        public int TagID { get; set; }

        public virtual Products Products { get; set; }

        public virtual Tags Tags { get; set; }
    }
}
