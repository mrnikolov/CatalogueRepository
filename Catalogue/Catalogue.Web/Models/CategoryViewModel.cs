using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}