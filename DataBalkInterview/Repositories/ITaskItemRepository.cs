using System;
using DataBalkInterview.Models;

namespace DataBalkInterview.Repositories
{
	public interface ITaskItemRepository
	{
        Task<TaskItem> GetByIdAsync(Guid id);
        Task<List<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(Guid id);

        bool IsTaskItemContextNull();
    }
}

