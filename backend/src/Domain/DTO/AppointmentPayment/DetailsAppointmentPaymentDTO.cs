using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTO.AppointmentPayment
{
    public class DetailsAppointmentPaymentDTO
    {
        public int Id { get; set; }
        public bool IsSignal { get; set; }
        public DateTime DatePayment { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [NotMapped]
        public string PaymentMethodName { get; set; }
    }
}