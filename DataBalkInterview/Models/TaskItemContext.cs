using System;
using Microsoft.EntityFrameworkCore;

namespace DataBalkInterview.Models
{
	public class TaskItemContext: DbContext
	{
        public TaskItemContext(DbContextOptions<TaskItemContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }

    }
}

