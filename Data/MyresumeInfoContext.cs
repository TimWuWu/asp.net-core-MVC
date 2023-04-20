using Microsoft.EntityFrameworkCore;
using MyResumeOfWPF.PDO;

namespace MyresumeWebApplication.Data
{
    public class MyresumeInfoContext: DbContext
    {
        public MyresumeInfoContext(DbContextOptions<MyresumeInfoContext> options):base(options)
        { 

        }

        public DbSet<BasicinfoRow> BasicinfoRows { get; set; }
        public DbSet<EducationRow> EducationRows { get; set; }
        public DbSet<SkillRow> SkillRows { get; set; }
        public DbSet<JobRow> JobRows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicinfoRow>().ToTable("Basics");
            modelBuilder.Entity<EducationRow>().ToTable("Educations");
            modelBuilder.Entity<SkillRow>().ToTable("Skills");
            modelBuilder.Entity<JobRow>().ToTable("Jobs");
        }
    }
}
