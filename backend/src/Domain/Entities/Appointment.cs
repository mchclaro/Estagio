using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DataHeld { get; set; }
        public Status Status { get; set; }
        public int EstimateId { get; set; }
        public int ClientId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<AppointmentPayment> AppointmentPayments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}