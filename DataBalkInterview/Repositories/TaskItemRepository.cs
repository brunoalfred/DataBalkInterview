using System;
using DataBalkInterview.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBalkInterview.Repositories
{
	public class TaskItemRepository: ITaskItemRepository
	{
        private readonly TaskItemContext _context;

        public TaskItemRepository(TaskItemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem task)
        {

            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            if (_context.TaskItems == null)
            {
                throw new NullReferenceException();
            }

            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(Guid id)
        {
            if (this.IsTaskItemContextNull())
            {
                throw new NullReferenceException();
            }
            var task = await _context.TaskItems.FindAsync(id);

            if (task == null)
            {
                throw new NullReferenceException();
            }

            return task;

        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TaskItemExists(task.Id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw ex;
                }

            }


        }
        public bool IsTaskItemContextNull()
        {
            return _context.TaskItems == null;
        }

        private bool TaskItemExists(Guid id)
        {
            return (_context.TaskItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

