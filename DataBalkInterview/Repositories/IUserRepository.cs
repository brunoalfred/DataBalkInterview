using System;
using DataBalkInterview.Models;

namespace DataBalkInterview.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);

        bool IsUserContextNull();
    }
}

