using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataBalkInterview.Helpers;

namespace DataBalkInterview.Models
{
	public class User
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Username { get; set; }

		[Required]
		[MaxLength(50)]
		public string Email { get; set; }

		[Required]
		[MaxLength(50)]
		public string Password { get; set; }

		[MaxLength(200)]
		public string? ApiKey { get; set; }

		// public ICollection<TaskItem>? TaskItems { get; set; }

		public User(
			string username,
			string email,
			string password
		)
		{
			Id = Guid.NewGuid();
			Username = username;
			Email = email;
			Password = password;
			ApiKey = RandomStringGenerator.GenerateRandomString(200);
		}


	}
}

