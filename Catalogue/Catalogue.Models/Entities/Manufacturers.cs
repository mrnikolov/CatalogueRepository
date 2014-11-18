namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        public int ManufacturerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
