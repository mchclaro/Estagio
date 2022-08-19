using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidateDate { get; set; }
        public int ClientId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Client Client { get; set; }
    }
}