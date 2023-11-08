using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataBalkInterview.Models
{
	public class TaskItem
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(150)]
		public string Title { get; set; }

		[MinLength(10)]
		public string Description { get; set; }

		[Required]
		public DateTime DueDate { get; set; }

		[Required]
		public Guid UserId { get; set; } // foreign key

		// public User? User { get; set; } // Navigation property

		public TaskItem(
			string title,
			string description,
			DateTime dueDate,
			Guid userId
		)
		{
			Id = Guid.NewGuid();
			Title = title;
			Description = description;
			DueDate = dueDate;
			UserId = userId;
		}

	}
}

