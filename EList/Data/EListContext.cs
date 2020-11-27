using EList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Data
{
    public class EListContext : DbContext
    {
        public EListContext(DbContextOptions<EListContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<List> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer($"Server=elistdb.cpgfkgne7e1e.us-east-2.rds.amazonaws.com;Database=EListDB;User ID= admin;Password=password;ConnectRetryCount=0;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
