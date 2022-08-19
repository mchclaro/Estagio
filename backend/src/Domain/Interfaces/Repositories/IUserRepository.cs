using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<User> Read(int id);
        Task<IList<User>> ReadAll();
        Task Update(int id, User user);
        Task<bool> Exists(int id);
        Task<bool> IsPhoneInUse(string phone);
        Task<bool> IsEmailInUse(string email);
        Task ChangePassword(int id, string password);
    }
}