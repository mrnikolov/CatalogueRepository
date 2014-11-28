﻿using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class CategoryListViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int Count { get; set; }
        public int? Page { get; set; }
    }
}