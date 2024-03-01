using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class SDBContext : DbContext
    {
       // public SDBContext(DbContextOptions<SDBContext> options) : base(options) { }
       // public SDBContext() { }
        //public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<TeacherPupil> TeacherPupils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeacherPupil>()
                .HasKey(tp => new { tp.Teacher_Id, tp.Pupil_Id });

            // Optionally, you can define relationships here if needed
            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Teacher)
                .WithMany(t => t.TeacherPupils)
                .HasForeignKey(tp => tp.Teacher_Id);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(tp => tp.Pupil)
                .WithMany(p => p.TeacherPupils)
                .HasForeignKey(tp => tp.Pupil_Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // {server=DESKTOP-4QUQTGO;database=TaTiaShopv1;trusted_connection=true;TrustServerCertificate=True;
            optionsBuilder.UseSqlServer("server=WINDOWS-E3QO2GR\\SQLEXPRESS; database=Task77;trusted_connection=true;TrustServerCertificate=True;");
            // }
        }

}
}
