using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaV1.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }
       
        public DbSet<DZguba> DZguby { get; set; }
        public DbSet<DUser> DUser { get; set; }


    }
}
