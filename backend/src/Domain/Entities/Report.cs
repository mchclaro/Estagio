using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public ReportsType Type { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentPaymentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual AppointmentPayment AppointmentPayment { get; set; }
    }
}