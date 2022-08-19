using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Filter;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        readonly DataContext _context;
        private readonly IAppointmentPaymentRepository _appointmentPaymentRepository;
        public AppointmentRepository(DataContext context, IAppointmentPaymentRepository appointmentPaymentRepository)
        {
            _context = context;
            _appointmentPaymentRepository = appointmentPaymentRepository;
        }

        public async Task<int> Create(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Appointments.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<dynamic> GetAllAppointments(AppointmentFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> Read(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Appointment>> ReadAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task Update(Appointment appointment)
        {
            var appoint = await _context.Appointments.FirstOrDefaultAsync(c => c.Id == appointment.Id);
            if (appoint != null)
            {
                appoint.Description = appointment.Description;
                appoint.DataHeld = appointment.DataHeld;
                appoint.Status = appointment.Status;
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == appointment.ClientId);
            if (client != null)
            {
                client.Name = appointment.Client.Name;
                client.Phone = appointment.Client.Phone;
            }

            var estimate = await _context.Estimates.FirstOrDefaultAsync(c => c.Id == appointment.ClientId);
            if (estimate != null)
            {
                estimate.Service= appointment.Estimate.Service;
                estimate.Description = appointment.Estimate.Description;
            }
            
            await _context.SaveChangesAsync();

            //atualiza os métodos de pagamento do agendamento
                await _appointmentPaymentRepository.Delete(appointment.Id);

                foreach (var id in appointment.PaymentMethodIds)
                {
                    await _appointmentPaymentRepository.Create(new AppointmentPayment
                    {
                        AppointmentId = appointment.Id,
                        PaymentMethodId = id
                    });
                }
        }
    }
}