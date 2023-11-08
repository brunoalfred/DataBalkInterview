using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBalkInterview.Models;
using DataBalkInterview.Repositories;

namespace DataBalkInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemRepository _taskRepository;

        public TaskItemController(ITaskItemRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        // GET: api/TaskItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            if (_taskRepository.IsTaskItemContextNull())
            {
                return NotFound();
            }

            return await _taskRepository.GetAllAsync();
        }

        // GET: api/TaskItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(Guid id)
        {
            if (_taskRepository.IsTaskItemContextNull())
            {
                return NotFound();
            }
            return await _taskRepository.GetByIdAsync(id);

        }

        // PUT: api/TaskItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(Guid id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            await _taskRepository.UpdateAsync(taskItem);

            return NoContent();
        }

        // POST: api/TaskItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
          if (_taskRepository.IsTaskItemContextNull())
          {
              return Problem("Entity set 'TaskItemContext.TaskItems'  is null.");
          }
            await _taskRepository.AddAsync(taskItem);

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
        }

        // DELETE: api/TaskItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(Guid id)
        {
            if (_taskRepository.IsTaskItemContextNull())
            {
                return NotFound();
            }
            var user = await _taskRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _taskRepository.DeleteAsync(id);

            return NoContent();
        }

       
    }
}
