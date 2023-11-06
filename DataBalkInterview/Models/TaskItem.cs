using System;
namespace DataBalkInterview.Models
{
	public class TaskItem
	{

		public int Id { get; set; }
		public string Title { get; set; }

		public string Description { get; set; }

		// relationship with user (assignee)
		public int UserId { get; set; }

		// due date
		public DateTime DueDate { get; set; }

		public TaskItem(
			int id,
			string title,
			string description,
			int userId,
			DateTime dueDate
		)
		{
			Id = id;
			Title = title;
			Description = description;
			UserId = userId;
			DueDate = dueDate;
		}

	}
}

