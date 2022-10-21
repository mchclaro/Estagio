using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO.PaymentMethod
{
    public class ListPaymentMethodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Domain.Entities.AppointmentPayment> AppointmentPayments { get; set; }
    }
}