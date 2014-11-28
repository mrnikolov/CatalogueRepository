﻿using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Models.Infrastructure
{
    public class PagedList<T>
    {
        public IEnumerable<T> Items { get; private set; }

        public int PageCount { get; private set; }

        public int CurrentPage { get; private set; }

        public PagedList(IQueryable<T> source, int? page, int pageSize)
        {
            CurrentPage = page.GetValueOrDefault(1);
            PageCount = ((int)(Math.Ceiling((double)source.Count() / pageSize)));
            Items = source.Skip((CurrentPage - 1) * pageSize).Take(pageSize);
        }
    }
}
