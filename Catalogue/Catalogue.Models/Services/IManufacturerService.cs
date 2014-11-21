using Catalogue.Models.Entities;
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

        Manufacturer Find(int? id);

        void Add(Manufacturer manufacturer);

        void Modify(Manufacturer manufacturer);

        void Remove(Manufacturer manufacturer);
    }
}
