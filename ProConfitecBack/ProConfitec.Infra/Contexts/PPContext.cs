using Microsoft.EntityFrameworkCore;
using ProConfitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Infra.Contexts
{
    public class PPContext : DbContext
    {
        public PPContext(DbContextOptions<PPContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SchoolRecords> SchoolRecords { get; set; }
        public DbSet<Scholarity> Scholarity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tb_user");
            modelBuilder.Entity<User>().HasKey(s => s.Id);

            modelBuilder.Entity<SchoolRecords>().ToTable("tb_school_records");
            modelBuilder.Entity<SchoolRecords>().HasKey(s => s.Id);

            modelBuilder.Entity<Scholarity>().ToTable("tb_scholarity");
            modelBuilder.Entity<Scholarity>().HasKey(s => s.Id);


            modelBuilder.Entity<User>()
            .HasOne<Scholarity>(s => s.Scholarity)
            .WithMany(g => g.Users)
            .HasForeignKey(s => s.ScholarityId);

            modelBuilder.Entity<User>()
            .HasOne<SchoolRecords>(s => s.SchoolRecords)
            .WithMany(g => g.Users)
            .HasForeignKey(s => s.SchoolRecordsId);
            

            modelBuilder.Entity<Scholarity>()
                .HasData(
                 new Scholarity(1,"Infantil"),
                 new Scholarity(2,"Fundamental"),
                 new Scholarity(3,"Médio"),
                 new Scholarity(4,"Superior")

                );
               
        }

    }
}
