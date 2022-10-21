using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.AppointmentPayment;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAppointmentPaymentRepository
    {
        Task<int> Create(AppointmentPayment appointmentPayment);
        Task<bool> Exists(int id);
        Task Delete(int appointmentId);
        Task<AppointmentPayment> Read(int id);
        Task<AppointmentPayment> CheckBalancePending();
        Task<AppointmentPayment> CheckBalanceConcluded();
    }
}