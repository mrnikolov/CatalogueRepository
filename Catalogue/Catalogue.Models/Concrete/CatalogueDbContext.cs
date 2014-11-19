using Catalogue.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Concrete
{
    public class CatalogueDbContext : IdentityDbContext<Users>
    {
        public CatalogueDbContext()
            : base("DefaultConnection")
        {
            #if DEBUG
                this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            #endif
                this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<LikesDislikes> LikesDislikes { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsTags> ProductsTags { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Wishlists> Wishlists { get; set; }
    }
}
