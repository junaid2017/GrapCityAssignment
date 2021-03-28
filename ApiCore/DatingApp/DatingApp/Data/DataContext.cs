using DatingApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base (options)
        {

        }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
    }
}
