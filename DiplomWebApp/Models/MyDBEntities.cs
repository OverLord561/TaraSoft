using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiplomWebApp.Models
{
    public class MyDBEntities : DbContext
    {
        public MyDBEntities() : base("MyDBEntities")
        {

        }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Firms> Firms { get; set; }
        
    }
}