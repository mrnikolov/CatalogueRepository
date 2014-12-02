using Catalogue.Models.Entities;
using Catalogue.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private const int pageSize = 10;

        public CategoryService(ICatalogueContext context)
            : base(context)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return this.Context.Categories.ToList();
        }

        public Category Find(int? id)
        {
            return this.Context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }


        public void Modify(Category category)
        {
            this.Context.Entry(category).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void Remove(Category category)
        {
            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var category = this.Find(id);
            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }

        public PagedList<Category> GetItems(int? page)
        {
            var pagedList = new PagedList<Category>(this.Context.Categories.OrderBy(c => c.Name), page, pageSize);
            return pagedList;
        }
    }
}
