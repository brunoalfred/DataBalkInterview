using System;
using DataBalkInterview.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBalkInterview.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            if (_context.Users == null)
            {
                throw new NullReferenceException();
            }

            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            if (this.IsUserContextNull())
            {
                throw new NullReferenceException();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            return user;

        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(user.Id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw ex;
                }

            }


        }
        public bool IsUserContextNull()
        {
            return _context.Users == null;
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}

