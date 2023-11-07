using System;
using DataBalkInterview.Models;

namespace DataBalkInterview.Repositories
{
	public interface ITaskItemRepository
	{
        Task<TaskItem> GetByIdAsync(int id);
        Task<List<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);

        bool IsTaskItemContextNull();
    }
}

