using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Filter;

namespace Domain.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<int> Create(Appointment appointment);
        Task<Appointment> Read(int id);
        Task<IList<Appointment>> ReadAll();
        Task Update(Appointment appointment);
        Task<bool> Exists(int id);
        Task<dynamic> GetAllAppointments(AppointmentFilter filter);
    }
}