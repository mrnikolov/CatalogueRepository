namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        [Key]
        public int ImageID { get; set; }

        public byte[] Value { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        public int ProductID { get; set; }

        public virtual Product Products { get; set; }
    }
}
