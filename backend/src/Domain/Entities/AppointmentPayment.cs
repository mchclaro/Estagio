using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class AppointmentPayment
    {
        public int Id { get; set; }
        public bool IsSignal { get; set; }
        public DateTime DatePayment { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int AppointmentId { get; set; }
        public int PaymentMethodId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        
    }
}