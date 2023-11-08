using Microsoft.EntityFrameworkCore;
namespace DataBalkInterview.Models;

public class UserContext : DbContext
{

	public UserContext(DbContextOptions<UserContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//TODO: hash the password before saving and save it 

		base.OnModelCreating(modelBuilder);
	}
}
