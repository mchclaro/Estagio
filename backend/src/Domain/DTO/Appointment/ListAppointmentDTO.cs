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
        public virtual Domain.Entities.Estimate Estimate { get; set; }
        public virtual Domain.Entities.Client Client { get; set; }
        public virtual ICollection<AppointmentPayment> AppointmentPayments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        
        [NotMapped]
        public int[] PaymentMethodIds { get; set; }
    }
}