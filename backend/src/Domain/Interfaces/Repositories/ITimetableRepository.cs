using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITimetableRepository
    {
        Task<int> Create(Timetable timetable);
    }
}