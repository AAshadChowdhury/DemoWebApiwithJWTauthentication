using DemoWebApi.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        { }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<purchasedetails>()
                .HasKey(c => new { c.purchaseId, c.slno });
            modelBuilder.Entity<salesdetails>()
             .HasKey(c => new { c.saleId, c.slno });

//            modelBuilder.Entity<roasters>()
//.HasKey(c => new { c.roasterid, c.slno });

//            modelBuilder.Entity<attendanceReport>()
//.HasKey(c => new { c.employeeid, c.slno, c.date });
//            modelBuilder.Entity<salarysheet>()
//.HasKey(c => new { c.year, c.month, c.empcode });

            //     modelBuilder.Entity<scales>()
            //.HasMany(t => t.designations)
            //.WithOne()
            //.HasPrincipalKey(u => u.scaleName);
            //modelBuilder.Entity<scales>()
            //.HasKey(bc => new { bc.scaleid, bc.scaleName });

            //modelBuilder.Entity<designations>()
            //    .HasOne(bc => bc.scales)
            //    .WithMany(b => b.designations)
            //    .HasForeignKey(bc => bc.scaleName);
            //modelBuilder.Entity<increments>()
            //    .HasOne(bc => bc.scales)
            //    .WithMany(c => c.increments)
            //    .HasForeignKey(bc => bc.scaleName);
            //modelBuilder.Entity<salary>()
            // .HasOne(bc => bc.scales)
            // .WithMany(c => c.salary)
            // .HasForeignKey(bc => bc.scaleName);



            //     modelBuilder.Entity<scales>()
            //.HasMany(t => t.increments)
            //.WithOne()
            //.HasPrincipalKey(u => u.scaleName);

            //     modelBuilder.Entity<scales>()
            //.HasMany(t => t.salary)
            //.WithOne()
            //.HasPrincipalKey(u => u.scaleName);
            // modelBuilder.Entity<increments>()
            //     .HasOne(s => s.scales)
            //     .WithMany(c => c.increments)
            //     .HasForeignKey(s => new { s.scaleName });

            // modelBuilder.Entity<salary>()
            //.HasOne(s => s.scales)
            //.WithMany(c => c.salary)
            //.HasForeignKey(s => new { s.scaleName });

            // modelBuilder.Entity<designations>()
            //.HasOne(s => s.scales)
            //.WithMany(c => c.designations)
            //.HasForeignKey(s => new { s.scaleName });
        }


        public DbSet<department> department { get; set; }
        public DbSet<items> items { get; set; }
        public DbSet<purchasedetails> purchasedetails { get; set; }
        public DbSet<purchasemaster> purchasemasters { get; set; }
        public DbSet<party> parties { get; set; }
        public DbSet<salesdetails> salesdetails { get; set; }
        public DbSet<salesemaster> salesemasters { get; set; }
        public DbSet<storeledger> storeledgers { get; set; }
        
    }
}
