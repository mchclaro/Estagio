using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public int AddressId { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Estimate> Estimates { get; set; }
    }
}