using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.models;
using Microsoft.EntityFrameworkCore;

namespace ayudantis1.src.Data
{
     public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
    }
}