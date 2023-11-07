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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            if (_userRepository.IsUserContextNull())
            {
                return NotFound();
            }

            return await _userRepository.GetAllAsync();

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_userRepository.IsUserContextNull())
            {
                return NotFound();
            }

            return await _userRepository.GetByIdAsync(id);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {

            if (id != user.Id)
            {
                return BadRequest();
            }

            // use the repository to update the user
            await _userRepository.UpdateAsync(user);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_userRepository.IsUserContextNull())
            {
                return Problem("Entity set 'UserContext.Users'  is null.");
            }

            if (null == user)
            {
                return BadRequest();
            }

            await _userRepository.AddAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_userRepository.IsUserContextNull())
            {
                return NotFound();
            }

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }


    }
}
