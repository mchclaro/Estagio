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
    public class ReportsRepository : IReportsRepository
    {
        readonly DataContext _context;
        public ReportsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Report reports)
        {
            await _context.Reports.AddAsync(reports);
            await _context.SaveChangesAsync();

            return reports.Id;
        }

        // public async Task<Report> Read(int id)
        // {
        //     return await _context.Reports.FirstOrDefaultAsync(c => c.Id == id);
        // }

        // public async Task<IList<Report>> ReadAll()
        // {
        //     return await _context.Reports.ToListAsync();
        // }
    }
}