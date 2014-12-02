using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class ProductListViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public int Count { get; set; }
        public int? Page { get; set; }
    }
}