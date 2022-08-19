using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IEstimateRepository
    {
        Task<int> Create(Estimate estimate);
        // Task<Estimate> Read(int id);
        Task<IList<Estimate>> ReadAll();
        // Task Update(int id, Estimate estimate);
        Task<bool> Exists(int id);
    }
}