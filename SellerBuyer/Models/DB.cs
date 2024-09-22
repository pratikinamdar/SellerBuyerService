using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Data.Common;
namespace SellerBuyer.Models
{
    public class DB : DbContext
    {
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public string connstr;
        private bool useInMemory;

        public DB(string connstr, bool isTest = false)
        {
            this.connstr = connstr;
            useInMemory = isTest;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (useInMemory)
            {
                options.UseInMemoryDatabase("DB");
            }
            else
            {
                options.UseSqlServer(connstr);
            }
        }
    }
}
