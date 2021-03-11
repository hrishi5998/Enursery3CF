using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Enursery3ccf.Models
{
    public class ENDbContext : DbContext
    {

        public DbSet<Nursery> Nurseries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        
    }
}