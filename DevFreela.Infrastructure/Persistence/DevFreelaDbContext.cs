using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.
                Entity<Skill>(e =>
                {
                    e.HasKey(s => s.Id);
                });

            builder.
                Entity<UserSkill>(e =>
                {
                    e.HasKey(us => us.Id);

                    e.HasOne(u => u.Skill)
                        .WithMany(s => s.UserSkills)
                        .HasForeignKey(s => s.SkillId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder.
                Entity<ProjectComment>(e =>
                {
                    e.HasKey(pc => pc.Id);

                    e.HasOne(pc => pc.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.ProjectId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(pc => pc.User)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder.
                Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Skills)
                        .WithOne(us => us.User)
                        .HasForeignKey(us => us.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder.
                Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Freelancer)
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(f => f.FreelancerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Customer)
                        .WithMany(f => f.OwnedProjects)
                        .HasForeignKey(f => f.CustomerId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}