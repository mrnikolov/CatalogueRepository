using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogue.Models.Abstract;
using Catalogue.Models.Entities;

namespace Catalogue.Models.Services
{
    public class EFProductRepository : IProductRepository
    {
        public IEnumerable<Products> Products { get; set; }
    }
}
