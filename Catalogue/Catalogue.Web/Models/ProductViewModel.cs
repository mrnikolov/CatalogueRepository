using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class ProductViewModel
    {
        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturers { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [DisplayName("Year of product")]
        public int ProductYear { get; set; }

        [Required]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}