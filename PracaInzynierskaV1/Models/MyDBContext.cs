using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracaInzynierskaV1.Models;

namespace PracaInzynierskaV1.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }
       
        public DbSet<DZguba> DZguby { get; set; }
        public DbSet<DUser> DUser { get; set; }
        public DbSet<DZguba_Zwierze> DZguba_Zwierze { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Elektronika> DZguba_Elektronika { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Ubranie> DZguba_Ubranie { get; set; }


    }
}
