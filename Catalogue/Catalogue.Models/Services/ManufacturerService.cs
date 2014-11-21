﻿using Catalogue.Models.Entities;
using System.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Services
{
    public class ManufacturerService: IManufacturerService
    {
        private CatalogueContext context;

        public ManufacturerService(CatalogueContext context)
        {
            this.context = context;
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return context.Manufacturers.ToList();
        }

        public Manufacturer Find(int? id)
        {
            return context.Manufacturers.Find(id);
        }

        public void Add(Manufacturer manufacturer)
        {
            context.Manufacturers.Add(manufacturer);
            context.SaveChanges();
        }

        public void Modify(Manufacturer manufacturer)
        {
            context.Entry(manufacturer).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Manufacturer manufacturer)
        {
            context.Manufacturers.Remove(manufacturer);
            context.SaveChanges();
        }
    }
}
