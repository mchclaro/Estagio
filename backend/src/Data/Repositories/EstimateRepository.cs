using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        readonly DataContext _context;
        public EstimateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Estimate estimate)
        {
            await _context.Estimates.AddAsync(estimate);
            await _context.SaveChangesAsync();

            return estimate.Id;
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Estimates.AnyAsync(c => c.Id == id);
            return res;
        }

        // public async Task<Estimate> Read(int id)
        // {
        //     return await _context.Estimates.FirstOrDefaultAsync(c => c.Id == id);
        // }

        public async Task<IList<Estimate>> ReadAll()
        {
            return await _context.Estimates
                .Include(x => x.Client)
                .ToListAsync();
        }

        // public async Task Update(int id, Estimate estimate)
        // {
        //     var res = await _context.Estimates.FirstOrDefaultAsync(c => c.Id == estimate.Id);

        //     if (res == null)
        //         return;

        //     //atributos do estimate
        //     res.Service = estimate.Service;
        //     res.Description = estimate.Description;
        //     res.Value = estimate.Value;
        //     res.ValidateDate = estimate.ValidateDate;

        //     await _context.SaveChangesAsync();
        // }
    }
}