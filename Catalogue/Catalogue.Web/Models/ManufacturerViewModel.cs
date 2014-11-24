using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class ManufacturerViewModel
    {
        public int ManufacturerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}