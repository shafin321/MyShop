﻿using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Sql
{
  public class DataContext:DbContext
    {
        public DataContext()
        
            :base("DefaultConnection"){

            }
        public DbSet<Product>Products { get; set; }
        public  DbSet<ProductCategory>productCategories { get; set; }
    }
    

}
