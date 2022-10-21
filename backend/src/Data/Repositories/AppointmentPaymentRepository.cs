using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.DTO.AppointmentPayment;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AppointmentPaymentRepository : IAppointmentPaymentRepository
    {
        readonly DataContext _context;
        public AppointmentPaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AppointmentPayment appointmentPayment)
        {
            await _context.AppointmentPayments.AddAsync(appointmentPayment);
            await _context.SaveChangesAsync();

            return appointmentPayment.Id;
        }

         public async Task Delete(int appointmentId)
        {
            var appointmentPaymentMethod = await _context.AppointmentPayments.FirstOrDefaultAsync(x => x.Id == appointmentId);

            if (appointmentPaymentMethod is null)
                return;

            _context.AppointmentPayments.RemoveRange(appointmentPaymentMethod);

            await _context.SaveChangesAsync();
        }

        public async Task<AppointmentPayment> Read(int id)
        {
            var res = await _context.AppointmentPayments
                .Include(a => a.Appointment)
                .Include(a => a.PaymentMethod)
                .Select(x => new AppointmentPayment
                {
                    Id = x.Id,
                    IsSignal = x.IsSignal,
                    DatePayment = x.DatePayment,
                    Value = x.Value,
                    PaymentStatus = x.PaymentStatus,
                    Appointment = new Appointment
                    {
                        Description = x.Appointment.Description,
                        DataHeld = x.Appointment.DataHeld,
                        Status = x.Appointment.Status
                    },
                    PaymentMethod = new PaymentMethod
                    {
                        Name = x.PaymentMethod.Name,
                    },
                }).FirstOrDefaultAsync(c => c.Id == id);

            return res;
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.AppointmentPayments.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<AppointmentPayment> CheckBalancePending()
        {
            var entity = await _context.AppointmentPayments
                    .Where(x => (int)x.PaymentStatus == 1)
                    .ToListAsync();

            var sum = entity.Sum(x => x.Value);
            var numbers = entity.Count();

            var res = new AppointmentPayment
            {
                Value = sum,
                Numbers = numbers
            };

            return res;
        }

        public async Task<AppointmentPayment> CheckBalanceConcluded()
        {
            var entity = await _context.AppointmentPayments
                    .Where(x => (int)x.PaymentStatus == 2)
                    .ToListAsync();

            var sum = entity.Sum(x => x.Value);
            var numbers = entity.Count();

            var res = new AppointmentPayment
            {
                Value = sum,
                Numbers = numbers
            };

            return res;
        }
       
    }
}