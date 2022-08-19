using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        readonly DataContext _context;
        public TimetableRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Timetable timetable)
        {
            await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();

            return timetable.Id;
        }
    }
}