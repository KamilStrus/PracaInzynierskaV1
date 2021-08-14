using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracaInzynierskaV1.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PracaInzynierskaV1.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DUser_DNagroda>()
                .HasOne(b => b.Nagroda)
                .WithMany(ba => ba.DUser_DNagroda)
                .HasForeignKey(bi => bi.DNagrodaID);

            modelBuilder.Entity<DUser_DNagroda>()
              .HasOne(b => b.User)
              .WithMany(ba => ba.DUser_DNagroda)
              .HasForeignKey(bi => bi.DUserID);

          

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DZguba> DZguby { get; set; }
        public DbSet<DUser> DUser { get; set; }

        public DbSet<DZguba_Zwierze> DZguba_Zwierze { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Elektronika> DZguba_Elektronika { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Ubranie> DZguba_Ubranie { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DNagroda> DNagroda { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DUser_DNagroda> DUser_DNagroda { get; set; }
        public DbSet<PracaInzynierskaV1.Models.Email> Email { get; set; }


    }
}
