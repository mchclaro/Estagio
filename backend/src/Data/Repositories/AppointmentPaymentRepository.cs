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

        public async Task<bool> Exists(int id)
        {
            var res = await _context.AppointmentPayments.AnyAsync(c => c.Id == id);
            return res;
        }
       
    }
}