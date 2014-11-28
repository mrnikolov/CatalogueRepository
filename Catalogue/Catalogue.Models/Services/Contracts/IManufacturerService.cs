using Catalogue.Models.Entities;
using Catalogue.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Services
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetAll();

        PagedList<Manufacturer> GetItems(int? page);

        Manufacturer Find(int? id);

        void Add(Manufacturer category);

        void Modify(Manufacturer category);

        void Remove(Manufacturer category);

        void Remove(int id);
    }
}
