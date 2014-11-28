using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class ManufacturerListViewModel
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public int Count { get; set; }
        public int? Page { get; set; }
    }
}