using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<int> Create(Client client);
        Task<Client> Read(int id);
        Task<IList<Client>> ReadAll();
        Task Update(Client client);
        Task<bool> Exists(int id);
        Task<bool> IsPhoneInUse(string phone);
        Task Delete(int id);
    }
}