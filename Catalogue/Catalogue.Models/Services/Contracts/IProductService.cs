using Catalogue.Models.Entities;
using Catalogue.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        PagedList<Product> GetItems(int? page);

        Product Find(int? id);

        void Add(Product category);

        void Add(Image image);

        void Modify(Product category);

        void Remove(Product category);

        void Remove(int id);
    }
}
