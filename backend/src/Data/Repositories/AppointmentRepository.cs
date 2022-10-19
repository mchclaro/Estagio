using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Filter;
using Domain.Interfaces.Repositories;
using FluentDate;
using FluentDateTime;
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
            var res = await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Estimate)
                .Include(a => a.AppointmentPayments)
                .Select(x => new Appointment
                {
                    Id = x.Id,
                    Description = x.Description,
                    DataHeld = x.DataHeld,
                    Status = x.Status,
                    //resolver problema aqui também, mesma coisa do ReadAll certeza
                    // Client = new Client
                    // {
                    //     Name = x.Client.Name,
                    //     Phone = x.Client.Phone,
                    //     PhotoUrl = x.Client.PhotoUrl
                    // },
                    // Estimate = new Estimate
                    // {
                    //     Service = x.Estimate.Service,
                    //     Description = x.Estimate.Description,
                    //     Value = x.Estimate.Value,
                    //     ValidateDate = x.Estimate.ValidateDate
                    // },
                    // AppointmentPayment = new AppointmentPayment
                    // {
                    //     IsSignal = x.AppointmentPayment.IsSignal,
                    //     DatePayment = x.AppointmentPayment.DatePayment,
                    //     Value = x.AppointmentPayment.Value,
                    //     PaymentStatus = x.AppointmentPayment.PaymentStatus,
                    //     PaymentMethodId = x.AppointmentPayment.PaymentMethodId
                    // },
                }).FirstOrDefaultAsync(c => c.Id == id);

            return res;
        }

        public async Task<IList<Appointment>> ReadAll()
        {
            return await _context.Appointments
                    // ta com erro quando faz include nessas tabelas, não achei o problema ainda, já mapeei mas n resolveu
                    // .Include(a => a.Client)
                    // .Include(a => a.Estimate)
                    // .Include(a => a.AppointmentPayments)
                    .ToListAsync();
        }

        public async Task Update(Appointment appointment)
        {
            var appoint = await _context.Appointments.FirstOrDefaultAsync(c => c.Id == appointment.Id);
            if (appoint != null)
            {
                appoint.Description = appointment.Description;
                appoint.DataHeld = appointment.DataHeld;
                appoint.Status = appointment.Status;
                appoint.ClientId = appointment.ClientId;
                appoint.EstimateId = appointment.EstimateId;
            }

            var estimate = await _context.Estimates.FirstOrDefaultAsync(c => c.Id == appointment.EstimateId);
            if (estimate != null)
            {
                estimate.Service= appointment.Estimate.Service;
                estimate.Description = appointment.Estimate.Description;
                estimate.Value = appointment.Estimate.Value;
                estimate.ClientId = appointment.ClientId;
            }
            
            await _context.SaveChangesAsync();

            
            //atualiza os métodos de pagamento do agendamento
            // await _appointmentPaymentRepository.Delete(appointment.Id);

            // foreach (var id in appointment.PaymentMethodIds)
            // {
            //     await _appointmentPaymentRepository.Create(new AppointmentPayment
            //     {
            //         AppointmentId = appointment.Id,
            //         PaymentMethodId = id
            //     });
            // }
        }

        public async Task<IList<Appointment>> DailyReport()
        {
            return await _context.Appointments
                    // ta com erro quando faz include nessas tabelas, não achei o problema ainda, já mapeei mas n resolveu
                    // .Include(a => a.Client)
                    // .Include(a => a.Estimate)
                    // .Include(a => a.AppointmentPayments)
                    .Where(x => x.DataHeld.Date == DateTime.Now.Date)
                    .ToListAsync();
        }

        public async Task<IList<Appointment>> WeeklyReport()
        {

            DateTime date = DateTime.Now.Date.AddDays(-7);

            return await _context.Appointments
                    // ta com erro quando faz include nessas tabelas, não achei o problema ainda, já mapeei mas n resolveu
                    // .Include(a => a.Client)
                    // .Include(a => a.Estimate)
                    // .Include(a => a.AppointmentPayments)
                    .Where(x => x.DataHeld.Date >= date && x.DataHeld <= DateTime.Now.Date)
                    .ToListAsync();
        }

        public async Task<IList<Appointment>> MonthReport()
        {
            return await _context.Appointments
                    // ta com erro quando faz include nessas tabelas, não achei o problema ainda, já mapeei mas n resolveu
                    // .Include(a => a.Client)
                    // .Include(a => a.Estimate)
                    // .Include(a => a.AppointmentPayments)
                    .Where(x => x.DataHeld.Date.Month >= DateTime.Now.Date.Month)
                    .ToListAsync();
        }
    }
}