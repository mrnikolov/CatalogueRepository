using Catalogue.Models.Entities;
using Catalogue.Models.Infrastructure;
using System;
using System.Collections.Generic;
namespace Catalogue.Models.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        PagedList<Category> GetItems(int? page);

        Category Find(int? id);

        void Add(Category category);

        void Modify(Category category);

        void Remove(Category category);

        void Remove(int id);
    }
}
