using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTO.Appointment
{
    public class ListAppointmentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DataHeld { get; set; }
        public Status Status { get; set; }
        public int EstimateId { get; set; }
        public int ClientId { get; set; }
        public virtual EstimateDTO Estimate { get; set; }
        public virtual ClientDTO Client { get; set; }
        public virtual ICollection<AppointmentPaymentDTO> AppointmentPayments { get; set; }

        public class ClientDTO 
        {
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        public class EstimateDTO 
        {
            public int Id { get; set; }
            public string Service { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public DateTime ValidateDate { get; set; }
        }

        public class AppointmentPaymentDTO 
        {
            public bool IsSignal { get; set; }
            public DateTime DatePayment { get; set; }
            public decimal Value { get; set; }
            public PaymentStatus PaymentStatus { get; set; }
            public string PaymentMethodName { get; set; }
        }
    }
}