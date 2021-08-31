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
        public DbSet<DZguba_Zwierze> DZguby_Zwierze { get; set; }
        public DbSet<DZguba_Zwierze> DZguby_Ubranie { get; set; }
        public DbSet<DZguba_Zwierze> DZguby_Elektronika { get; set; }
       // public DbSet<Gatunek> Gatunki { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<DUser_DNagroda>()
                .HasOne(b => b.Nagroda)
                .WithMany(ba => ba.DUser_DNagroda)
                .HasForeignKey(bi => bi.DNagrodaID);

            modelBuilder.Entity<DUser_DNagroda>()
              .HasOne(b => b.User)
              .WithMany(ba => ba.DUser_DNagroda)
              .HasForeignKey(bi => bi.DUserID);


            modelBuilder.Entity<DZguba_Zwierze>()
           .HasOne(p => p.Gatunek)
           .WithMany(b => b.DZguby_Zwierze)
           .HasForeignKey(p => p.GatunekId);

            modelBuilder.Entity<DZguba_Ubranie>()
          .HasOne(p => p.RodzajUbranie)
          .WithMany(b => b.DZguby_Ubranie)
          .HasForeignKey(p => p.RodzajUbranieId);

            modelBuilder.Entity<DZguba_Ubranie>()
          .HasOne(p => p.MarkaUbranie)
          .WithMany(b => b.DZguby_Ubranie)
          .HasForeignKey(p => p.MarkaUbranieId);


            modelBuilder.Entity<DZguba_Elektronika>()
         .HasOne(p => p.RodzajElektronika)
         .WithMany(b => b.DZguby_Elektronika)
         .HasForeignKey(p => p.RodzajElektronikaId);

            modelBuilder.Entity<DZguba_Elektronika>()
         .HasOne(p => p.Producents)
         .WithMany(b => b.DZguby_Elektronika)
         .HasForeignKey(p => p.ProducentsId);

           
        }

        public DbSet<DZguba> DZguby { get; set; }
        public DbSet<DUser> DUser { get; set; }

        public DbSet<DZguba_Zwierze> DZguba_Zwierze { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Elektronika> DZguba_Elektronika { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DZguba_Ubranie> DZguba_Ubranie { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DNagroda> DNagroda { get; set; }
        public DbSet<PracaInzynierskaV1.Models.DUser_DNagroda> DUser_DNagroda { get; set; }
        public DbSet<PracaInzynierskaV1.Models.Email> Email { get; set; }

        public DbSet<PracaInzynierskaV1.Models.Producents> Producents { get; set; }

        public DbSet<PracaInzynierskaV1.Models.Gatunek> Gatunek { get; set; }

        public DbSet<PracaInzynierskaV1.Models.RodzajElektronika> RodzajElektronika { get; set; }

        public DbSet<PracaInzynierskaV1.Models.RodzajUbranie> RodzajUbranie { get; set; }

        public DbSet<PracaInzynierskaV1.Models.MarkaUbranie> MarkaUbranie { get; set; }


    }
}
