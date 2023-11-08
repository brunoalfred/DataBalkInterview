using System;
using Microsoft.EntityFrameworkCore;

namespace DataBalkInterview.Models
{
    public class TaskItemContext : DbContext
    {
        public TaskItemContext(DbContextOptions<TaskItemContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TaskItem>()
            //.HasOne(e => e.User)
            //.WithMany(e => e.TaskItems)
            //.HasForeignKey(e => e.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}

