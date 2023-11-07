using System;
using DataBalkInterview.Models;

namespace DataBalkInterview.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        bool IsUserContextNull();
    }
}

