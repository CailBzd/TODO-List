using Microsoft.EntityFrameworkCore;
using TODO.Domain.Models;

namespace TODO.Infra.Contexts
{
    public class TODOContext : DbContext
    {
        public TODOContext(DbContextOptions<TODOContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary K
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<TaskItem>().HasKey(ti => ti.Id);

            //Foreign K
            modelBuilder.Entity<TaskItem>().HasOne(ti => ti.User).WithMany(u => u.Tasks);
        }
    }
}
