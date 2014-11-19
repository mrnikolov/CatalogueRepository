namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int ProductCategoryID { get; set; }

        public int CategoryID { get; set; }

        public int ProductID { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Products Products { get; set; }
    }
}
