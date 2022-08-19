using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Filter
{
    public class AppointmentFilter
    {
        public DateTime? DataHeld { get; set; }
        public int? Status { get; set; }
        public int? ClientId { get; set; }
        public int? EstimateId { get; set; }
        public int? ServiceId { get; set; }
    }
}